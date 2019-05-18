import { NegociacaoService } from './../services/Index';
import { Negociacoes, Negociacao } from "../models/index";
import { NegociacoesView, MensagemView } from "../views/Index";
import { domInject, throttle } from "../helpers/decorators/index";
import { imprime } from '../helpers/Index';

export class NegociacaoController{

    @domInject("#data")
    private _inputData: JQuery;

    @domInject("#quantidade")
    private _inputQuantidade: JQuery;

    @domInject("#valor")
    private _inputValor: JQuery;

    private _negociacoes = new Negociacoes();
    private _negociacoesView = new NegociacoesView('#negociacoesView');
    private _mensagemView = new MensagemView('#mensagemView');

    private _negociacaoService = new NegociacaoService();

    constructor(){
        this._negociacoesView.update(this._negociacoes);
    }

    @throttle()
    public adiciona(): void{
        
        let data = new Date(this._inputData.val().replace(/-/g, ','));

        if(!this._EhDiaUtil(data)){
            this._mensagemView.update("Somente negociações em dias úteis, por favor");
            return;
        }

        const negociacao = new Negociacao(
            data,
            parseInt(this._inputQuantidade.val()),
            parseFloat(this._inputValor.val())
        );

        imprime(negociacao, this._negociacoes);

        this._negociacoes.adiciona(negociacao);
        this._negociacoesView.update(this._negociacoes);
        this._mensagemView.update("Negociação adicionada com sucesso!");
    }

    private _EhDiaUtil(data: Date): boolean{
        return data.getDay() != DiaDaSemana.Sábado && data.getDay() != DiaDaSemana.Domingo;
    }

    @throttle()
    importaDados(){
        this._negociacaoService
            .obterNegociacoes(res => {
                if(res.ok) return res;
                else throw new Error(res.statusText);
            })
            .then(negociacoesParaImportar =>{

                const negociacoesJaImportadas = this._negociacoes.paraArray();
                if(negociacoesParaImportar){

                    negociacoesParaImportar
                        .filter(negociacao => 
                            !negociacoesJaImportadas
                                .some(jaImportada => negociacao.ehIgual(jaImportada))
                        
                        ).forEach(negocicao => 
                            this._negociacoes.adiciona(negocicao));
                            
                    this._negociacoesView.update(this._negociacoes);
                }

            });
    }
}

enum DiaDaSemana{
    Domingo,
    Segunda,
    Terça,
    Quarta,
    Quinta,
    Sexta,
    Sábado
}
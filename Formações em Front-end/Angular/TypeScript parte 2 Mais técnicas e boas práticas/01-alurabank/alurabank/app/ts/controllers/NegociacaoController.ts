import { Negociacoes, Negociacao } from "../models/index";
import { NegociacoesView, MensagemView } from "../views/Index";
import { domInject } from "../helpers/decorators/index";

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

    constructor(){
        this._negociacoesView.update(this._negociacoes);
    }

    public adiciona(event: Event): void{
        event.preventDefault();
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
        
        this._negociacoes.adiciona(negociacao);
        this._negociacoesView.update(this._negociacoes);
        this._mensagemView.update("Negociação adicionada com sucesso!");
    }

    private _EhDiaUtil(data: Date): boolean{
        return data.getDay() != DiaDaSemana.Sábado && data.getDay() != DiaDaSemana.Domingo;
    }

    importaDados(){
        alert("oi");
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
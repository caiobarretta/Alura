System.register(["./../services/Index", "../models/index", "../views/Index", "../helpers/decorators/index", "../helpers/Index"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var Index_1, index_1, Index_2, index_2, Index_3, NegociacaoController, DiaDaSemana;
    return {
        setters: [
            function (Index_1_1) {
                Index_1 = Index_1_1;
            },
            function (index_1_1) {
                index_1 = index_1_1;
            },
            function (Index_2_1) {
                Index_2 = Index_2_1;
            },
            function (index_2_1) {
                index_2 = index_2_1;
            },
            function (Index_3_1) {
                Index_3 = Index_3_1;
            }
        ],
        execute: function () {
            NegociacaoController = class NegociacaoController {
                constructor() {
                    this._negociacoes = new index_1.Negociacoes();
                    this._negociacoesView = new Index_2.NegociacoesView('#negociacoesView');
                    this._mensagemView = new Index_2.MensagemView('#mensagemView');
                    this._negociacaoService = new Index_1.NegociacaoService();
                    this._negociacoesView.update(this._negociacoes);
                }
                adiciona() {
                    let data = new Date(this._inputData.val().replace(/-/g, ','));
                    if (!this._EhDiaUtil(data)) {
                        this._mensagemView.update("Somente negociações em dias úteis, por favor");
                        return;
                    }
                    const negociacao = new index_1.Negociacao(data, parseInt(this._inputQuantidade.val()), parseFloat(this._inputValor.val()));
                    Index_3.imprime(negociacao, this._negociacoes);
                    this._negociacoes.adiciona(negociacao);
                    this._negociacoesView.update(this._negociacoes);
                    this._mensagemView.update("Negociação adicionada com sucesso!");
                }
                _EhDiaUtil(data) {
                    return data.getDay() != DiaDaSemana.Sábado && data.getDay() != DiaDaSemana.Domingo;
                }
                importaDados() {
                    this._negociacaoService
                        .obterNegociacoes(res => {
                        if (res.ok)
                            return res;
                        else
                            throw new Error(res.statusText);
                    })
                        .then(negociacoesParaImportar => {
                        const negociacoesJaImportadas = this._negociacoes.paraArray();
                        if (negociacoesParaImportar) {
                            negociacoesParaImportar
                                .filter(negociacao => !negociacoesJaImportadas
                                .some(jaImportada => negociacao.ehIgual(jaImportada))).forEach(negocicao => this._negociacoes.adiciona(negocicao));
                            this._negociacoesView.update(this._negociacoes);
                        }
                    });
                }
            };
            __decorate([
                index_2.domInject("#data")
            ], NegociacaoController.prototype, "_inputData", void 0);
            __decorate([
                index_2.domInject("#quantidade")
            ], NegociacaoController.prototype, "_inputQuantidade", void 0);
            __decorate([
                index_2.domInject("#valor")
            ], NegociacaoController.prototype, "_inputValor", void 0);
            __decorate([
                index_2.throttle()
            ], NegociacaoController.prototype, "adiciona", null);
            __decorate([
                index_2.throttle()
            ], NegociacaoController.prototype, "importaDados", null);
            exports_1("NegociacaoController", NegociacaoController);
            (function (DiaDaSemana) {
                DiaDaSemana[DiaDaSemana["Domingo"] = 0] = "Domingo";
                DiaDaSemana[DiaDaSemana["Segunda"] = 1] = "Segunda";
                DiaDaSemana[DiaDaSemana["Ter\u00E7a"] = 2] = "Ter\u00E7a";
                DiaDaSemana[DiaDaSemana["Quarta"] = 3] = "Quarta";
                DiaDaSemana[DiaDaSemana["Quinta"] = 4] = "Quinta";
                DiaDaSemana[DiaDaSemana["Sexta"] = 5] = "Sexta";
                DiaDaSemana[DiaDaSemana["S\u00E1bado"] = 6] = "S\u00E1bado";
            })(DiaDaSemana || (DiaDaSemana = {}));
        }
    };
});

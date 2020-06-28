from unittest import TestCase
from src.leilao.dominio import Usuario, Lance, Leilao, Avaliador


class TestAvaliador(TestCase):

    # test_quando_adicionados_em_ordem_crescente_deve_retornar_o_maior_e_o_menor_valor_de_um_lance
    def test_deve_retornar_o_maior_e_o_menor_valor_de_um_lance_quando_adicionados_em_ordem_crescente(self):
        gui = Usuario('Gui')
        yuri = Usuario('Yuri')

        lance_do_yuri = Lance(yuri, 100.0)
        lance_do_gui = Lance(gui, 150.0)

        leilao = Leilao('Celular')
        leilao.lances.append(lance_do_yuri)
        leilao.lances.append(lance_do_gui)

        avalidador = Avaliador()
        avalidador.avalia(leilao)
        menor_valor_esperado = 100.0
        maior_valor_esperado = 150.0

        self.assertEqual(menor_valor_esperado, avalidador.menor_lance)
        self.assertEqual(maior_valor_esperado, avalidador.maior_lance)

    def test_deve_retornar_o_maior_e_o_menor_valor_de_um_lance_quando_adicionados_em_ordem_decrescente(self):
        gui = Usuario('Gui')
        yuri = Usuario('Yuri')

        lance_do_yuri = Lance(yuri, 100.0)
        lance_do_gui = Lance(gui, 150.0)

        leilao = Leilao('Celular')

        leilao.lances.append(lance_do_gui)
        leilao.lances.append(lance_do_yuri)

        avalidador = Avaliador()
        avalidador.avalia(leilao)
        menor_valor_esperado = 100.0
        maior_valor_esperado = 150.0

        self.assertEqual(menor_valor_esperado, avalidador.menor_lance)
        self.assertEqual(maior_valor_esperado, avalidador.maior_lance)

    def test_deve_retornarn_o_mesmo_valor_para_o_maior_e_menor_lance_quando_leilao_tiver_um_lance(self):
        gui = Usuario('Gui')

        lance = Lance(gui, 150.0)

        leilao = Leilao('Celular')
        leilao.lances.append(lance)

        avaliador = Avaliador()
        avaliador.avalia(leilao)

        self.assertEqual(150.0, avaliador.menor_lance)
        self.assertEqual(150.0, avaliador.maior_lance)

    def test_deve_retornar_o_maior_e_o_menor_valor_quando_o_leilao_tiver_tres_lances(self):
        gui = Usuario('Gui')
        yuri = Usuario('Yuri')
        vini = Usuario ('Vini')

        lance_do_yuri = Lance(yuri, 100.0)
        lance_do_gui = Lance(gui, 150.0)
        lance_do_vini = Lance(vini, 200.0)

        leilao = Leilao('Celular')
        leilao.lances.append(lance_do_yuri)
        leilao.lances.append(lance_do_gui)
        leilao.lances.append(lance_do_vini)

        avalidador = Avaliador()
        avalidador.avalia(leilao)
        menor_valor_esperado = 100.0
        maior_valor_esperado = 200.0

        self.assertEqual(menor_valor_esperado, avalidador.menor_lance)
        self.assertEqual(maior_valor_esperado, avalidador.maior_lance)
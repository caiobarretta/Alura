from unittest import TestCase
from src.leilao.dominio import Usuario, Lance, Leilao, Avaliador


class TestAvaliador(TestCase):

    def test_avalia(self):
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

    def test_avalia2(self):
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

from src.leilao.dominio import Usuario, Lance, Leilao, Avaliador

gui = Usuario('Gui')
yuri = Usuario('Yuri')

lance_do_yuri = Lance(yuri, 100)
lance_do_gui = Lance(gui, 150)

leilao = Leilao('Celular')
leilao.lances.append(lance_do_yuri)
leilao.lances.append(lance_do_gui)

for lance in leilao.lances:
    print(f'O usuário {lance.usuario.nome} deu um lance de {lance.valor}')

avalidador = Avaliador()
avalidador.avalia(leilao)

print(f'O menor lance foi de {avalidador.menor_lance} e o maior lance foi de {avalidador.maior_lance}')

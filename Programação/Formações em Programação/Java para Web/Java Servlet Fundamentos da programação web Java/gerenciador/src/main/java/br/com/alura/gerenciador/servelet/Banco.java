package br.com.alura.gerenciador.servelet;

import java.util.ArrayList;
import java.util.List;

public class Banco {
	
	private static List<Empresa> lista = new ArrayList<>();
	
	static {
		var empresa = new Empresa();
		empresa.setNome("Teste");
		var empresa2 = new Empresa();
		empresa2.setNome("Teste2");
		lista.add(empresa);
		lista.add(empresa2);
	}

	public void adiciona(Empresa empresa) {
		lista.add(empresa);
	}
	
	public List<Empresa> getEmpresas(){
		return Banco.lista;
	}
	
}

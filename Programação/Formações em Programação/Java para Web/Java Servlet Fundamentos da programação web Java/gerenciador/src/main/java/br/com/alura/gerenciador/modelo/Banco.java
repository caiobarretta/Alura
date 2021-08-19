package br.com.alura.gerenciador.modelo;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Banco {
	
	private static List<Empresa> lista = new ArrayList<Empresa>();
	private static List<Usuario> listaUsuarios = new ArrayList<Usuario>();
	private static Integer chaveSequencial = 1;
	
	static {
		var empresa = new Empresa();
		empresa.setId(Banco.chaveSequencial++);
		empresa.setNome("Teste");
		var empresa2 = new Empresa();
		empresa2.setId(Banco.chaveSequencial++);
		empresa2.setNome("Teste2");
		lista.add(empresa);
		lista.add(empresa2);
		
		var u1 = new Usuario();
		u1.setLogin("caio");
		u1.setSenha("1234");
		var u2 = new Usuario();
		u2.setLogin("caio");
		u2.setSenha("1234");
		
		listaUsuarios.add(u1);
		listaUsuarios.add(u2);
	}

	public void adiciona(Empresa empresa) {
		empresa.setId(Banco.chaveSequencial++);
		lista.add(empresa);
	}
	
	public List<Empresa> getEmpresas(){
		return Banco.lista;
	}

	public void removeEmpresa(Integer id) {
		for (Iterator<Empresa> iterator = lista.iterator(); iterator.hasNext();) {
			var empresa = iterator.next();
			if(empresa.getId() == id) {
				iterator.remove();
			}
		}
	}

	public Empresa buscaEmpresaPelaId(Integer id) {
		for (Empresa empresa : lista) {
			if(empresa.getId() == id) {
				return empresa;
			}
		}
		return null;
	}
	
}

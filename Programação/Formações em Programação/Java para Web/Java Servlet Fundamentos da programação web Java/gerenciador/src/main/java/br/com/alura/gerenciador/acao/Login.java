package br.com.alura.gerenciador.acao;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class Login implements Acao {

	@Override
	public String executa(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		var login = request.getParameter("login");
		var senha = request.getParameter("senha");
		
		
		return "redirect:entrada?acao=ListaEmpresas";
	}

}

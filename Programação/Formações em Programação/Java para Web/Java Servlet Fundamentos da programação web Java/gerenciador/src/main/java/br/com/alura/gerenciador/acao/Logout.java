package br.com.alura.gerenciador.acao;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class Logout implements Acao {

	@Override
	public String executa(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		var sessao = request.getSession();
		sessao.invalidate();
		
		return "redirect:entrada?acao=LoginForm";
	}

}

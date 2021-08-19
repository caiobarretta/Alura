package br.com.alura.gerenciador.acao;

import java.io.IOException;
import br.com.alura.gerenciador.modelo.Banco;
import br.com.alura.gerenciador.modelo.Usuario;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class Login implements Acao {

	@Override
	public String executa(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		var login = request.getParameter("login");
		var senha = request.getParameter("senha");
		
		var banco = new Banco();
		Usuario usuario = banco.existeUsuario(login, senha);
		if(usuario != null) {
			var sessao = request.getSession();
			sessao.setAttribute("usuarioLogado", usuario);
			return "redirect:entrada?acao=ListaEmpresas";
		}
		return "redirect:entrada?acao=LoginForm";
	}
}

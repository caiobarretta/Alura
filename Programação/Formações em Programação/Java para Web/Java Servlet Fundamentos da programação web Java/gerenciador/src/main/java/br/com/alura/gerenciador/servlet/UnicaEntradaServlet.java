package br.com.alura.gerenciador.servlet;

import java.io.IOException;

import br.com.alura.gerenciador.acao.AlteraEmpresa;
import br.com.alura.gerenciador.acao.ListaEmpresas;
import br.com.alura.gerenciador.acao.MostraEmpresa;
import br.com.alura.gerenciador.acao.NovaEmpresa;
import br.com.alura.gerenciador.acao.RemoveEmpresa;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class UnicaEntradaServlet
 */
@WebServlet("/entrada")
public class UnicaEntradaServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		var paramAcao = request.getParameter("acao");
		if(paramAcao.equals("ListaEmpresas")) {
			var acao = new ListaEmpresas();
			acao.executa(request, response);
		}else if(paramAcao.equals("RemoveEmpresa")) {
			var acao = new RemoveEmpresa();
			acao.executa(request, response);
		}else if(paramAcao.equals("MostraEmpresa")) {
			var acao = new MostraEmpresa();
			acao.executa(request, response);
		}else if(paramAcao.equals("AlteraEmpresa")) {
			var acao = new AlteraEmpresa();
			acao.executa(request, response);
		}else if(paramAcao.equals("NovaEmpresa")) {
			var acao = new NovaEmpresa();
			acao.executa(request, response);
		}
	}

}

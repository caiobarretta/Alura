package br.com.alura.gerenciador.servlet;

import java.io.IOException;

import br.com.alura.gerenciador.acao.ListaEmpresas;
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
			System.out.println("Removendo empresa");
		}else if(paramAcao.equals("MostraEmpresa")) {
			System.out.println("Mostrando empresa");
		}
	}

}

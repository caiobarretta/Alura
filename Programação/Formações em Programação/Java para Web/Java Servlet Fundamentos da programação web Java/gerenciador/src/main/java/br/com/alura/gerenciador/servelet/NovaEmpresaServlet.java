package br.com.alura.gerenciador.servelet;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class NovaEmpresaServlet
 */
@WebServlet("/novaEmpresa")
public class NovaEmpresaServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	/**
	 * @see HttpServlet#service(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		var nomeEmpresa =  request.getParameter("nome");
		
		var out = response.getWriter();
		out.println("<html>");
		out.println("<body>");
		out.println(nomeEmpresa + " Empresa cadastrada com sucesso!");
		out.println("</body>");
		out.println("</html>");
	}

}

package br.com.alura.gerenciador.servelet;

import java.io.IOException;
import java.util.Iterator;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class ListaEmpresasServLet
 */
@WebServlet("/listaEmpresas")
public class ListaEmpresasServLet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) 
			throws ServletException, IOException {
		Banco banco = new Banco();
		var lista = banco.getEmpresas();
		var out = response.getWriter();
		out.println("<html>");
		out.println("<body>");
		
		out.println("<ul>");
		
		for (Empresa empresa : lista) {
			out.println("<li>");
			out.println(empresa.getNome());
			out.println("</li>");
		}
		
		out.println("</ul>");
		
		out.println("</body>");
		out.println("</html>");
	}

}

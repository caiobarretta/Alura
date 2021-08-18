package br.com.alura.gerenciador.acao;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import br.com.alura.gerenciador.modelo.Banco;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class AlteraEmpresa {
	public String executa(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		var paramId = request.getParameter("id");
		var nomeEmpresa =  request.getParameter("nome");
		var paramDataEmpresa =  request.getParameter("data");
		Date dataAbertura = null;
		
		var id = Integer.valueOf(paramId);
		try {
			var sdf = new SimpleDateFormat("dd/MM/yyyy");
			dataAbertura = sdf.parse(paramDataEmpresa);
		} catch (ParseException e) {
			throw new ServletException(e);
		}
		
		var banco = new Banco();
		var empresa = banco.buscaEmpresaPelaId(id);
		empresa.setNome(nomeEmpresa);
		empresa.setDataAbertura(dataAbertura);
		
		return "redirect:entrada?acao=ListaEmpresas";
	}
	
}

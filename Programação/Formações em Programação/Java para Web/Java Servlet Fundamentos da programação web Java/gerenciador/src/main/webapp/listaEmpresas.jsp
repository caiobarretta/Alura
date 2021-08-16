<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
<%@ page import="java.util.List, br.com.alura.gerenciador.servelet.Empresa" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<c:url value="/removeEmpresa" var="linkServletRemoveEmpresa"/>
<c:url value="/mostraEmpresa" var="linkServletMostraEmpresa"/>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Lista de empresas - Java Standard TabLib</title>
</head>
<body>
	<c:if test="${not empty empresa}">
			Empresa: ${empresa} cadastrada com sucesso! <br/>
	</c:if>
	Lista de empresa: <br/>
	<ul>
		<c:forEach items="${empresas}" var="empresa">
			<li>
				${empresa.nome} - <fmt:formatDate value="${empresa.dataAbertura}" pattern="dd/MM/yyyy"/>
				<a href="${linkServletMostraEmpresa}?id=${empresa.id}">editar</a>
				<a href="${linkServletRemoveEmpresa}?id=${empresa.id}">remover</a>
			</li>
		</c:forEach>
	</ul>
</body>
</html>
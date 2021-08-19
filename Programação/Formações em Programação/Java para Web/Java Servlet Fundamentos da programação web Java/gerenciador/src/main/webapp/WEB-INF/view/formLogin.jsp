<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<c:url value="/entrada" var="linkServletEntrada"/>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login</title>
</head>
<body>
	
	<form action="${linkServletEntrada}" method="post">
		Login: <input type="text" name="nome" />
		Senha: <input type="password" name="data" />
		<input type="hidden" name="acao" value="Login" />
		
		<input type="submit"/>
	</form>
</body>
</html>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>

<!DOCTYPE html>
<html>
    <head>
		<title>
		Welkom Chess
		</title>
		<style>
		body {
			background-color: #357236;
			text-align: center;
			font-size: 5em;
			
		}
		.button {
			height: 75px;
            width: 100px;
			background-color: Brown;
			font-style: italic;
			font-size: 0.4em
		}
		.groot{
			font-style: italic;
			font-size: 40em
		}
		
		</style>
	</head>	
	<body>
		<br>	
		<img src="Sogyo-Logo.jpg" alt=""><br>
		Welcome to Chess!<br>	
		<div style="font-size: 0.5em">
		<form action="Servlet1" method="post">
		Please enter your names:<br>
		Player 1(white): <input type="text" name = "name1"><br>
		Player 2(black): <input type="text" name = "name2"><br><br>
		<input type="Submit" class = "button"  value = "Lets play!">
		</form>
		</div>
		
		<div>
		
		<img src="pon.png" alt="hello">
		
		</div>
		
		
    </body>
</html>
<!DOCTYPE html>
<html>
    <head>
		<title>
		Welkom Mancala
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
		
		</style>
	</head>	
	<body>
		<br>	
		<img src="Sogyo-Logo.jpg" alt=""><br>
		Welcome to Mancala!<br>	
		<div style="font-size: 0.5em">
		<form action="Servlet1" method="post">
		Please enter your names:<br>
		Player 1: <input type="text" name = "name1"><br>
		Player 2: <input type="text" name = "name2"><br><br>
		<input type="Submit" class = "button"  value = "Lets play!">
		</form>
		</div>
    </body>
</html>
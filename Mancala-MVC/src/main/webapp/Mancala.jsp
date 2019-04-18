<!DOCTYPE html>
<html>
    <head>
        <title>Mancala</title>
        <style>
            body {
                font-size: 2em;
                font-family: monospace;
                text-align: center;
				background-color: #357236;
            }
            #board {
                display: flex;
                position: absolute;
                left: 0px;
                top: 0px;
                right: 0px;
                bottom: 0px;
                flex-direction: column;
                justify-content: center;
                align-items: center;
				
            }
            .cup {
				font-size: 2em;
                height: 180px;
                width: 180px;
                float: left;
                border: 0.5px solid black;
				background-color: #8B4513
            }			
			.kal {
				font-size: 2em;
                height: 300px;
                width: 180px;
                float: left;
                border: 1px solid black;
				background-color: #8B4513				
            }
			.inv {
				font-size: 1em;
                height: 300px;
                width: 900px;
                float: left;
                border: 0px solid black;
            }
			.small{
				font-size: 0.5em;								
			}			
            .cup:hover {
                cursor: pointer;
            }			
		
        </style>
    </head>

    <body>	
		<jsp:useBean id="messageBean" class="nl.sogyo.MessageBean" scope="session"/>
		<jsp:useBean id="pitBean" class="nl.sogyo.PitBean" scope="session"/>
		<jsp:useBean id="nameBean" class="nl.sogyo.NameBean" scope="session"/>
        
		<img src="Sogyo-Logo.jpg" alt="Sogyo" align = "left" style="height:100px;width:100px"> 
		<div id="board">
			<jsp:getProperty name="messageBean" property="moveMessage"/><br><br>					
			<jsp:getProperty name="nameBean" property="player1"/>:				
			<div>
				<form action="Servlet1" method="post" id="move">
					<button name="cupChoice" value= "0" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup1"/></button>			
					<button name="cupChoice" value= "1" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup2"/></button>
					<button name="cupChoice" value= "2" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup3"/></button>
					<button name="cupChoice" value= "3" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup4"/></button>
					<button name="cupChoice" value= "4" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup5"/></button>				
					<button name="cupChoice" value= "5" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup6"/></button>
				</form>				
			</div>
			<div>
				<div class="kal 14"></br></br><jsp:getProperty name="pitBean" property="kal14"/></div> 
				<div class="inv">																	
					<br><br>
					<jsp:getProperty name="messageBean" property="turnMessage"/><br>
					<jsp:getProperty name="messageBean" property="winnerMessage"/><br>
					<jsp:getProperty name="messageBean" property="standingMessage"/>
					</div>	
				<div class="kal 7"></br></br><jsp:getProperty name="pitBean" property="kal7"/></div>
				
			</div>
			<div>
				<form action="Servlet1" method="post" id="move">
					<button name="cupChoice" value= "12" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup13"/></button>                
					<button name="cupChoice" value= "11" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup12"/></button>				
					<button name="cupChoice" value= "10" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup11"/></button>
					<button name="cupChoice" value= "9" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup10"/></button>
					<button name="cupChoice" value= "8" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup9"/></button>
					<button name="cupChoice" value= "7" type= "submit" form= "move" class="cup"><jsp:getProperty name="pitBean" property="cup8"/></button>
				</form>
			</div>			
			<div><jsp:getProperty name="nameBean" property="player2"/>:</div>												
		</div>
    </body>
</html>
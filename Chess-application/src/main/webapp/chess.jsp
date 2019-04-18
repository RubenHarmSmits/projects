<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>

<!DOCTYPE html>
<html>
    <head>
        <title>Chess</title>
        <style>
		 
		 body{
				display: flex;
                position: absolute;
                left: 0px;
                top: 0px;
                right: 0px;
                bottom: 0px;
                flex-direction: column;
                justify-content: center;
                align-items: center;
				background-color: #357236;
				font-style:italic;
				
		 }
		 
		 .vakje{			 
			 height: 85px;
			 width: 85px;			 
			 float: left;
			 background-color: #F3D8B5;
			 display: flex;
			justify-content: center;
			align-items: center;
			font-style:italic;
			font-size: 23px;
			


			 
		 }
		 .zwart{
			 background-color: #B88665;			 
		 }
		 
			 
		 .white{
			 color: white;

		 }
		 
		 .color{
			 display:none;
		 }
            
        </style>
    </head>

    <body>
	
		<jsp:useBean id="BoardBean" class="chess.schaak.BoardBean" scope="session"/>
		
		
		<form action="Servlet1" method="post">
		<div>
		<button type="submit" class="vakje" name="zet" value="00"><jsp:getProperty name="BoardBean" property="box00"/></button>		
		<button type="submit" class="vakje zwart" name="zet" value = "01"><jsp:getProperty name="BoardBean" property="box01"/></button>
		<button type="submit" class="vakje" name="zet" value="02"><jsp:getProperty name="BoardBean" property="box02"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "03"><jsp:getProperty name="BoardBean" property="box03"/></button>
		<button type="submit" class="vakje" name="zet" value="04"><jsp:getProperty name="BoardBean" property="box04"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "05"><jsp:getProperty name="BoardBean" property="box05"/></button>
		<button type="submit" class="vakje" name="zet" value="06"><jsp:getProperty name="BoardBean" property="box06"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "07"><jsp:getProperty name="BoardBean" property="box07"/></button>
		</div>
		
		
		<div>
		<button type="submit" class="vakje zwart" name="zet" value="10"><jsp:getProperty name="BoardBean" property="box10"/></button>
		<button type="submit" class="vakje" name="zet" value = "11"><jsp:getProperty name="BoardBean" property="box11"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="12"><jsp:getProperty name="BoardBean" property="box12"/></button>
		<button type="submit" class="vakje" name="zet" value = "13"><jsp:getProperty name="BoardBean" property="box13"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="14"><jsp:getProperty name="BoardBean" property="box14"/></button>
		<button type="submit" class="vakje" name="zet" value = "15"><jsp:getProperty name="BoardBean" property="box15"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="16"><jsp:getProperty name="BoardBean" property="box16"/></button>
		<button type="submit" class="vakje" name="zet" value = "17"><jsp:getProperty name="BoardBean" property="box17"/></button>
		</div>
		
		<div>
		<button type="submit" class="vakje" name="zet" value="20"><jsp:getProperty name="BoardBean" property="box20"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "21"><jsp:getProperty name="BoardBean" property="box21"/></button>
		<button type="submit" class="vakje" name="zet" value="22"><jsp:getProperty name="BoardBean" property="box22"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "23"><jsp:getProperty name="BoardBean" property="box23"/></button>
		<button type="submit" class="vakje" name="zet" value="24"><jsp:getProperty name="BoardBean" property="box24"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "25"><jsp:getProperty name="BoardBean" property="box25"/></button>
		<button type="submit" class="vakje" name="zet" value="26"><jsp:getProperty name="BoardBean" property="box26"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "27"><jsp:getProperty name="BoardBean" property="box27"/></button>
		</div>
		
		
		
		<div>
		<button type="submit" class="vakje zwart" name="zet" value="30"><jsp:getProperty name="BoardBean" property="box30"/></button>
		<button type="submit" class="vakje" name="zet" value = "31"><jsp:getProperty name="BoardBean" property="box31"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="32"><jsp:getProperty name="BoardBean" property="box32"/></button>
		<button type="submit" class="vakje" name="zet" value = "33"><jsp:getProperty name="BoardBean" property="box33"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="34"><jsp:getProperty name="BoardBean" property="box34"/></button>
		<button type="submit" class="vakje" name="zet" value = "35"><jsp:getProperty name="BoardBean" property="box35"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="36"><jsp:getProperty name="BoardBean" property="box36"/></button>
		<button type="submit" class="vakje" name="zet" value = "37"><jsp:getProperty name="BoardBean" property="box37"/></button>
		</div>
		
		<div>
		<button type="submit" class="vakje" name="zet" value="40"><jsp:getProperty name="BoardBean" property="box40"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "41"><jsp:getProperty name="BoardBean" property="box41"/></button>
		<button type="submit" class="vakje" name="zet" value="42"><jsp:getProperty name="BoardBean" property="box42"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "43"><jsp:getProperty name="BoardBean" property="box43"/></button>
		<button type="submit" class="vakje" name="zet" value="44"><jsp:getProperty name="BoardBean" property="box44"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "45"><jsp:getProperty name="BoardBean" property="box45"/></button>
		<button type="submit" class="vakje" name="zet" value="46"><jsp:getProperty name="BoardBean" property="box46"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "47"><jsp:getProperty name="BoardBean" property="box47"/></button>
		</div>
		
		
		<div>
		<button type="submit" class="vakje zwart" name="zet" value="50"><jsp:getProperty name="BoardBean" property="box50"/></button>
		<button type="submit" class="vakje" name="zet" value = "51"><jsp:getProperty name="BoardBean" property="box51"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="52"><jsp:getProperty name="BoardBean" property="box52"/></button>
		<button type="submit" class="vakje" name="zet" value = "53"><jsp:getProperty name="BoardBean" property="box53"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="54"><jsp:getProperty name="BoardBean" property="box54"/></button>
		<button type="submit" class="vakje" name="zet" value = "55"><jsp:getProperty name="BoardBean" property="box55"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="56"><jsp:getProperty name="BoardBean" property="box56"/></button>
		<button type="submit" class="vakje" name="zet" value = "57"><jsp:getProperty name="BoardBean" property="box57"/></button>
		</div>
		
		<div>
		<button type="submit" class="vakje" name="zet" value="60"><jsp:getProperty name="BoardBean" property="box60"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "61"><jsp:getProperty name="BoardBean" property="box61"/></button>
		<button type="submit" class="vakje" name="zet" value="62"><jsp:getProperty name="BoardBean" property="box62"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "63"><jsp:getProperty name="BoardBean" property="box63"/></button>
		<button type="submit" class="vakje" name="zet" value="64"><jsp:getProperty name="BoardBean" property="box64"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "65"><jsp:getProperty name="BoardBean" property="box65"/></button>
		<button type="submit" class="vakje" name="zet" value="66"><jsp:getProperty name="BoardBean" property="box66"/></button>
		<button type="submit" class="vakje zwart" name="zet" value = "67"><jsp:getProperty name="BoardBean" property="box67"/></button>
		</div>
		
		
		<div>
		<button type="submit" class="vakje zwart" name="zet" value="70"><jsp:getProperty name="BoardBean" property="box70"/></button>
		<button type="submit" class="vakje" name="zet" value = "71"><jsp:getProperty name="BoardBean" property="box71"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="72"><jsp:getProperty name="BoardBean" property="box72"/></button>
		<button type="submit" class="vakje" name="zet" value = "73"><jsp:getProperty name="BoardBean" property="box73"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="74"><jsp:getProperty name="BoardBean" property="box74"/></button>
		<button type="submit" class="vakje" name="zet" value = "75"><jsp:getProperty name="BoardBean" property="box75"/></button>
		<button type="submit" class="vakje zwart" name="zet" value="76"><jsp:getProperty name="BoardBean" property="box76"/></button>
		<button type="submit" class="vakje" name="zet" value = "77" id="laatste"><jsp:getProperty name="BoardBean" property="box77"/></button>
		</div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox00"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox01"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox02"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox03"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox04"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox05"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox06"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox07"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox10"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox11"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox12"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox13"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox14"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox15"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox16"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox17"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox20"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox21"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox22"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox23"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox24"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox25"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox26"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox27"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox30"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox31"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox32"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox33"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox34"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox35"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox36"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox37"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox40"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox41"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox42"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox43"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox44"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox45"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox46"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox47"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox50"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox51"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox52"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox53"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox54"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox55"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox56"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox57"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox60"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox61"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox62"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox63"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox64"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox65"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox66"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox67"/></div>
		
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox70"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox71"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox72"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox73"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox74"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox75"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox76"/></div>
		<div class = "color"> <jsp:getProperty name="BoardBean" property="colorBox77"/></div>
		
		
		
		</form>
				
		
		<script>
		var container = document.querySelectorAll(".vakje");
		var colors = document.querySelectorAll(".color");
		
		console.log(colors[0].innerText.length);
		console.log(colors[0].innerText===true);
		console.log(colors[10])
		
	
		
		for(var i=0;i<container.length;i++) {
			container[i].innerHTML = "<img src="+getColor(i)+getPiece(container[i].innerHTML)+' alt=""/>';
		}
		
		function getPiece(information){
			
			//console.log(information);
				
			return (information+".png");
		}
		function getColor(i){
			
			if(colors[i].innerText.length===5)return "white";	
			if(colors[i].innerText.length===6)return "black";
			
			
			
		}
		

		</script>
		
		
    </body>
</html>
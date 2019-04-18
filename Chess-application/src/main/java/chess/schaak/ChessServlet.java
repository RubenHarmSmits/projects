package chess.schaak;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class ChessServlet extends HttpServlet {
  
	protected void doGet (HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {		
		
		SchaakApplication game = new SchaakApplication();
		
		HttpSession session = request.getSession();
		
		boolean first=true;
		
		boolean white = game.getBoard().getBoxes()[1][0].getPiece().getColorIsWhite();
		
		session.setAttribute("color", white);
		session.setAttribute("first",first);
		session.setAttribute("BoardBean", makeBoardBean(game));
		session.setAttribute("game", game);
				
		RequestDispatcher rd = request.getRequestDispatcher("chess.jsp");	
		rd.forward(request,response);
		
		
   }  
   
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {											
		
		
		
		HttpSession session = request.getSession();
		SchaakApplication game = (SchaakApplication)session.getAttribute("game");
		
	
		String zet = request.getParameter("zet").toString();
		System.out.println(zet);
		
		boolean first = (boolean)session.getAttribute("first");
		
		if(first) {
			session.setAttribute("original", zet);
		} 
		else {
			String original = (String)session.getAttribute("original");
			game.move(original+zet);
		}
		first=!first;
		
		session.setAttribute("BoardBean", makeBoardBean(game));
		session.setAttribute("game", game);
		session.setAttribute("first", first);
		
		
		RequestDispatcher rd = request.getRequestDispatcher("chess.jsp");	
		rd.forward(request,response);
	}
   
   BoardBean makeBoardBean(SchaakApplication game){
	   
	   BoardBean bb = new BoardBean();
	   
	   bb.setColorBox00(game.getBoard().getBoxes()[0][0].getPiece().colorIsWhite);
	   bb.setColorBox01(game.getBoard().getBoxes()[0][1].getPiece().colorIsWhite);
	   bb.setColorBox02(game.getBoard().getBoxes()[0][2].getPiece().colorIsWhite);
	   bb.setColorBox03(game.getBoard().getBoxes()[0][3].getPiece().colorIsWhite);
	   bb.setColorBox04(game.getBoard().getBoxes()[0][4].getPiece().colorIsWhite);
	   bb.setColorBox05(game.getBoard().getBoxes()[0][5].getPiece().colorIsWhite);
	   bb.setColorBox06(game.getBoard().getBoxes()[0][6].getPiece().colorIsWhite);
	   bb.setColorBox07(game.getBoard().getBoxes()[0][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox10(game.getBoard().getBoxes()[1][0].getPiece().colorIsWhite);
	   bb.setColorBox11(game.getBoard().getBoxes()[1][1].getPiece().colorIsWhite);
	   bb.setColorBox12(game.getBoard().getBoxes()[1][2].getPiece().colorIsWhite);
	   bb.setColorBox13(game.getBoard().getBoxes()[1][3].getPiece().colorIsWhite);
	   bb.setColorBox14(game.getBoard().getBoxes()[1][4].getPiece().colorIsWhite);
	   bb.setColorBox15(game.getBoard().getBoxes()[1][5].getPiece().colorIsWhite);
	   bb.setColorBox16(game.getBoard().getBoxes()[1][6].getPiece().colorIsWhite);
	   bb.setColorBox17(game.getBoard().getBoxes()[1][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox20(game.getBoard().getBoxes()[2][0].getPiece().colorIsWhite);
	   bb.setColorBox21(game.getBoard().getBoxes()[2][1].getPiece().colorIsWhite);
	   bb.setColorBox22(game.getBoard().getBoxes()[2][2].getPiece().colorIsWhite);
	   bb.setColorBox23(game.getBoard().getBoxes()[2][3].getPiece().colorIsWhite);
	   bb.setColorBox24(game.getBoard().getBoxes()[2][4].getPiece().colorIsWhite);
	   bb.setColorBox25(game.getBoard().getBoxes()[2][5].getPiece().colorIsWhite);
	   bb.setColorBox26(game.getBoard().getBoxes()[2][6].getPiece().colorIsWhite);
	   bb.setColorBox27(game.getBoard().getBoxes()[2][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox30(game.getBoard().getBoxes()[3][0].getPiece().colorIsWhite);
	   bb.setColorBox31(game.getBoard().getBoxes()[3][1].getPiece().colorIsWhite);
	   bb.setColorBox32(game.getBoard().getBoxes()[3][2].getPiece().colorIsWhite);
	   bb.setColorBox33(game.getBoard().getBoxes()[3][3].getPiece().colorIsWhite);
	   bb.setColorBox34(game.getBoard().getBoxes()[3][4].getPiece().colorIsWhite);
	   bb.setColorBox35(game.getBoard().getBoxes()[3][5].getPiece().colorIsWhite);
	   bb.setColorBox36(game.getBoard().getBoxes()[3][6].getPiece().colorIsWhite);
	   bb.setColorBox37(game.getBoard().getBoxes()[3][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox40(game.getBoard().getBoxes()[4][0].getPiece().colorIsWhite);
	   bb.setColorBox41(game.getBoard().getBoxes()[4][1].getPiece().colorIsWhite);
	   bb.setColorBox42(game.getBoard().getBoxes()[4][2].getPiece().colorIsWhite);
	   bb.setColorBox43(game.getBoard().getBoxes()[4][3].getPiece().colorIsWhite);
	   bb.setColorBox44(game.getBoard().getBoxes()[4][4].getPiece().colorIsWhite);
	   bb.setColorBox45(game.getBoard().getBoxes()[4][5].getPiece().colorIsWhite);
	   bb.setColorBox46(game.getBoard().getBoxes()[4][6].getPiece().colorIsWhite);
	   bb.setColorBox47(game.getBoard().getBoxes()[4][7].getPiece().colorIsWhite);
	   
	   
	   bb.setColorBox50(game.getBoard().getBoxes()[5][0].getPiece().colorIsWhite);
	   bb.setColorBox51(game.getBoard().getBoxes()[5][1].getPiece().colorIsWhite);
	   bb.setColorBox52(game.getBoard().getBoxes()[5][2].getPiece().colorIsWhite);
	   bb.setColorBox53(game.getBoard().getBoxes()[5][3].getPiece().colorIsWhite);
	   bb.setColorBox54(game.getBoard().getBoxes()[5][4].getPiece().colorIsWhite);
	   bb.setColorBox55(game.getBoard().getBoxes()[5][5].getPiece().colorIsWhite);
	   bb.setColorBox56(game.getBoard().getBoxes()[5][6].getPiece().colorIsWhite);
	   bb.setColorBox57(game.getBoard().getBoxes()[5][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox60(game.getBoard().getBoxes()[6][0].getPiece().colorIsWhite);
	   bb.setColorBox61(game.getBoard().getBoxes()[6][1].getPiece().colorIsWhite);
	   bb.setColorBox62(game.getBoard().getBoxes()[6][2].getPiece().colorIsWhite);
	   bb.setColorBox63(game.getBoard().getBoxes()[6][3].getPiece().colorIsWhite);
	   bb.setColorBox64(game.getBoard().getBoxes()[6][4].getPiece().colorIsWhite);
	   bb.setColorBox65(game.getBoard().getBoxes()[6][5].getPiece().colorIsWhite);
	   bb.setColorBox66(game.getBoard().getBoxes()[6][6].getPiece().colorIsWhite);
	   bb.setColorBox67(game.getBoard().getBoxes()[6][7].getPiece().colorIsWhite);
	   
	   bb.setColorBox70(game.getBoard().getBoxes()[7][0].getPiece().colorIsWhite);
	   bb.setColorBox71(game.getBoard().getBoxes()[7][1].getPiece().colorIsWhite);
	   bb.setColorBox72(game.getBoard().getBoxes()[7][2].getPiece().colorIsWhite);
	   bb.setColorBox73(game.getBoard().getBoxes()[7][3].getPiece().colorIsWhite);
	   bb.setColorBox74(game.getBoard().getBoxes()[7][4].getPiece().colorIsWhite);
	   bb.setColorBox75(game.getBoard().getBoxes()[7][5].getPiece().colorIsWhite);
	   bb.setColorBox76(game.getBoard().getBoxes()[7][6].getPiece().colorIsWhite);
	   bb.setColorBox77(game.getBoard().getBoxes()[7][7].getPiece().colorIsWhite);
	   
	   
	   
	   String box00 = game.getBoard().getBoxes()[0][0].getPiece().getType().toString(); bb.setBox00(box00);	   
	   String box01 = game.getBoard().getBoxes()[0][1].getPiece().getType().toString(); bb.setBox01(box01);
	   String box02 = game.getBoard().getBoxes()[0][2].getPiece().getType().toString(); bb.setBox02(box02);	   
	   String box03 = game.getBoard().getBoxes()[0][3].getPiece().getType().toString(); bb.setBox03(box03);
	   String box04 = game.getBoard().getBoxes()[0][4].getPiece().getType().toString(); bb.setBox04(box04);	   
	   String box05 = game.getBoard().getBoxes()[0][5].getPiece().getType().toString(); bb.setBox05(box05);
	   String box06 = game.getBoard().getBoxes()[0][6].getPiece().getType().toString(); bb.setBox06(box06);	   
	   String box07 = game.getBoard().getBoxes()[0][7].getPiece().getType().toString(); bb.setBox07(box07);
	   
	   String box10 = game.getBoard().getBoxes()[1][0].getPiece().getType().toString(); bb.setBox10(box10);	   
	   String box11 = game.getBoard().getBoxes()[1][1].getPiece().getType().toString(); bb.setBox11(box11);
	   String box12 = game.getBoard().getBoxes()[1][2].getPiece().getType().toString(); bb.setBox12(box12);	   
	   String box13 = game.getBoard().getBoxes()[1][3].getPiece().getType().toString(); bb.setBox13(box13);
	   String box14 = game.getBoard().getBoxes()[1][4].getPiece().getType().toString(); bb.setBox14(box14);	   
	   String box15 = game.getBoard().getBoxes()[1][5].getPiece().getType().toString(); bb.setBox15(box15);
	   String box16 = game.getBoard().getBoxes()[1][6].getPiece().getType().toString(); bb.setBox16(box16);	   
	   String box17 = game.getBoard().getBoxes()[1][7].getPiece().getType().toString(); bb.setBox17(box17);
	   
	   String box20 = game.getBoard().getBoxes()[2][0].getPiece().getType().toString(); bb.setBox20(box20);	   
	   String box21 = game.getBoard().getBoxes()[2][1].getPiece().getType().toString(); bb.setBox21(box21);
	   String box22 = game.getBoard().getBoxes()[2][2].getPiece().getType().toString(); bb.setBox22(box22);	   
	   String box23 = game.getBoard().getBoxes()[2][3].getPiece().getType().toString(); bb.setBox23(box23);
	   String box24 = game.getBoard().getBoxes()[2][4].getPiece().getType().toString(); bb.setBox24(box24);	   
	   String box25 = game.getBoard().getBoxes()[2][5].getPiece().getType().toString(); bb.setBox25(box25);
	   String box26 = game.getBoard().getBoxes()[2][6].getPiece().getType().toString(); bb.setBox26(box26);	   
	   String box27 = game.getBoard().getBoxes()[2][7].getPiece().getType().toString(); bb.setBox27(box27);
	   
	   String box30 = game.getBoard().getBoxes()[3][0].getPiece().getType().toString(); bb.setBox30(box30);	   
	   String box31 = game.getBoard().getBoxes()[3][1].getPiece().getType().toString(); bb.setBox31(box31);
	   String box32 = game.getBoard().getBoxes()[3][2].getPiece().getType().toString(); bb.setBox32(box32);	   
	   String box33 = game.getBoard().getBoxes()[3][3].getPiece().getType().toString(); bb.setBox33(box33);
	   String box34 = game.getBoard().getBoxes()[3][4].getPiece().getType().toString(); bb.setBox34(box34);	   
	   String box35 = game.getBoard().getBoxes()[3][5].getPiece().getType().toString(); bb.setBox35(box35);
	   String box36 = game.getBoard().getBoxes()[3][6].getPiece().getType().toString(); bb.setBox36(box36);	   
	   String box37 = game.getBoard().getBoxes()[3][7].getPiece().getType().toString(); bb.setBox37(box37);
	   
	   String box40 = game.getBoard().getBoxes()[4][0].getPiece().getType().toString(); bb.setBox40(box40);	   
	   String box41 = game.getBoard().getBoxes()[4][1].getPiece().getType().toString(); bb.setBox41(box41);
	   String box42 = game.getBoard().getBoxes()[4][2].getPiece().getType().toString(); bb.setBox42(box42);	   
	   String box43 = game.getBoard().getBoxes()[4][3].getPiece().getType().toString(); bb.setBox43(box43);
	   String box44 = game.getBoard().getBoxes()[4][4].getPiece().getType().toString(); bb.setBox44(box44);	   
	   String box45 = game.getBoard().getBoxes()[4][5].getPiece().getType().toString(); bb.setBox45(box45);
	   String box46 = game.getBoard().getBoxes()[4][6].getPiece().getType().toString(); bb.setBox46(box46);	   
	   String box47 = game.getBoard().getBoxes()[4][7].getPiece().getType().toString(); bb.setBox47(box47);
	   
	   String box50 = game.getBoard().getBoxes()[5][0].getPiece().getType().toString(); bb.setBox50(box50);	   
	   String box51 = game.getBoard().getBoxes()[5][1].getPiece().getType().toString(); bb.setBox51(box51);
	   String box52 = game.getBoard().getBoxes()[5][2].getPiece().getType().toString(); bb.setBox52(box52);	   
	   String box53 = game.getBoard().getBoxes()[5][3].getPiece().getType().toString(); bb.setBox53(box53);
	   String box54 = game.getBoard().getBoxes()[5][4].getPiece().getType().toString(); bb.setBox54(box54);	   
	   String box55 = game.getBoard().getBoxes()[5][5].getPiece().getType().toString(); bb.setBox55(box55);
	   String box56 = game.getBoard().getBoxes()[5][6].getPiece().getType().toString(); bb.setBox56(box56);	   
	   String box57 = game.getBoard().getBoxes()[5][7].getPiece().getType().toString(); bb.setBox57(box57);
	   
	   String box60 = game.getBoard().getBoxes()[6][0].getPiece().getType().toString(); bb.setBox60(box60);	   
	   String box61 = game.getBoard().getBoxes()[6][1].getPiece().getType().toString(); bb.setBox61(box61);
	   String box62 = game.getBoard().getBoxes()[6][2].getPiece().getType().toString(); bb.setBox62(box62);	   
	   String box63 = game.getBoard().getBoxes()[6][3].getPiece().getType().toString(); bb.setBox63(box63);
	   String box64 = game.getBoard().getBoxes()[6][4].getPiece().getType().toString(); bb.setBox64(box64);	   
	   String box65 = game.getBoard().getBoxes()[6][5].getPiece().getType().toString(); bb.setBox65(box65);
	   String box66 = game.getBoard().getBoxes()[6][6].getPiece().getType().toString(); bb.setBox66(box66);	   
	   String box67 = game.getBoard().getBoxes()[6][7].getPiece().getType().toString(); bb.setBox67(box67);
	   
	   String box70 = game.getBoard().getBoxes()[7][0].getPiece().getType().toString(); bb.setBox70(box70);	   
	   String box71 = game.getBoard().getBoxes()[7][1].getPiece().getType().toString(); bb.setBox71(box71);
	   String box72 = game.getBoard().getBoxes()[7][2].getPiece().getType().toString(); bb.setBox72(box72);	   
	   String box73 = game.getBoard().getBoxes()[7][3].getPiece().getType().toString(); bb.setBox73(box73);
	   String box74 = game.getBoard().getBoxes()[7][4].getPiece().getType().toString(); bb.setBox74(box74);	   
	   String box75 = game.getBoard().getBoxes()[7][5].getPiece().getType().toString(); bb.setBox75(box75);
	   String box76 = game.getBoard().getBoxes()[7][6].getPiece().getType().toString(); bb.setBox76(box76);	   
	   String box77 = game.getBoard().getBoxes()[7][7].getPiece().getType().toString(); bb.setBox77(box77);
	   
	   

	   
	   
	   return bb;
	   
	   
   }
	
  }

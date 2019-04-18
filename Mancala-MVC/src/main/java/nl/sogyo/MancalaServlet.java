package nl.sogyo;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class MancalaServlet extends HttpServlet {
   protected void doGet (HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {		
		HttpSession session = request.getSession();	
		Mancala mancala = new Mancala(6);			
		PitBean pitBean = makePitBean(mancala);		
		NameBean nameBean = makeNameBean(request);
		MessageBean messageBean = setUpMessageBean(nameBean);
						
		session.setAttribute("mancala", mancala);
		session.setAttribute("pitBean", pitBean);
		session.setAttribute("messageBean", messageBean);
		session.setAttribute("nameBean", nameBean);
   }  
   protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {											
		try{			
			HttpSession session = request.getSession();	
			int cupNumber = Integer.parseInt(request.getParameter("cupChoice"));			
			Mancala mancala  = (Mancala)session.getAttribute("mancala");
			NameBean nameBean = (NameBean)session.getAttribute("nameBean");
			MessageBean messageBean = makeMessageBean(mancala, cupNumber);
			((Cup)mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),cupNumber)).move();
			PitBean pitBean = makePitBean(mancala);	
			session.setAttribute("messageBean",updateMessageBean(mancala,messageBean,request));				  
			session.setAttribute("pitBean",pitBean);
			if(((Cup)mancala.getStartingCup().findWichKalToCheck().getNeighbour()).checkIfGameEnded()){				
				makeWinnerMessage(mancala, messageBean, nameBean);
				session.setAttribute("messageBean",messageBean);
			} 
		}
		catch(NumberFormatException e){
			doGet(request, response);
		}		
		RequestDispatcher rd = request.getRequestDispatcher("mancala.jsp");
		rd.forward(request, response);		
	}
	private MessageBean setUpMessageBean(NameBean nameBean){
		MessageBean messageBean = new MessageBean();
		messageBean.setTurnMessage(nameBean.getPlayer1()+", it is your turn!");
		messageBean.setMoveMessage("");
		messageBean.setWinnerMessage("");
		messageBean.setStandingMessage("");
		return messageBean;
	}  	
	private MessageBean makeMessageBean(Mancala m, int vakje){
		MessageBean pitBean = new MessageBean();
		if(m.getStartingCup().getOwner().isMyTurn()){
			if(vakje>=0&&vakje<=5) {
				if(m.getStartingCup().getNeighbourN(m.getStartingCup(),vakje).getStones()==0){
					pitBean.setMoveMessage("You chose a Cup without stones, please choose a Cup with stones!");
				}
				else pitBean.setMoveMessage("");
			}
			else pitBean.setMoveMessage("Please choose on of your own cups!");
		}
		else {
			if(vakje>=7&&vakje<=12) {
				if(m.getStartingCup().getNeighbourN(m.getStartingCup(),vakje).getStones()==0){
					pitBean.setMoveMessage("You chose a Cup without stones, please choose a Cup with stones!");
				}
				else pitBean.setMoveMessage("");
			}
			else pitBean.setMoveMessage("Please choose on of your own cups!");
		}
		pitBean.setWinnerMessage(" ");
		pitBean.setStandingMessage("");
		return pitBean;
	}
	private MessageBean updateMessageBean(Mancala mancala, MessageBean pitBean, HttpServletRequest request){
		HttpSession session = request.getSession();	
		NameBean nameBean = ((NameBean)session.getAttribute("nameBean"));
		
		if(mancala.getStartingCup().getOwner().isMyTurn()){
			
			pitBean.setTurnMessage(nameBean.getPlayer1()+ ", it is your turn!");
		}
		else {
			pitBean.setTurnMessage(nameBean.getPlayer2()+", it is your turn!");
		}									
		return pitBean;
	}
	private PitBean makePitBean(Mancala mancala){
		PitBean pitBean = new PitBean();		
		pitBean.setCup1(mancala.getStartingCup().getStones());
		pitBean.setCup2(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),1).getStones());
		pitBean.setCup3(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),2).getStones());
		pitBean.setCup4(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),3).getStones());
		pitBean.setCup5(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),4).getStones());
		pitBean.setCup6(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),5).getStones());
		pitBean.setKal7(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),6).getStones());
		pitBean.setCup8(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),7).getStones());
		pitBean.setCup9(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),8).getStones());
		pitBean.setCup10(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),9).getStones());
		pitBean.setCup11(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),10).getStones());
		pitBean.setCup12(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),11).getStones());
		pitBean.setCup13(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),12).getStones());
		pitBean.setKal14(mancala.getStartingCup().getNeighbourN(mancala.getStartingCup(),13).getStones());		
		return pitBean;
	}	
	private NameBean makeNameBean (HttpServletRequest request){
		NameBean nameBean = new NameBean();
		nameBean.setPlayer1(request.getParameter("name1"));
		nameBean.setPlayer2(request.getParameter("name2"));
		return nameBean;
	}	

	private void makeWinnerMessage(Mancala m, MessageBean messageBean, NameBean nameBean){
		messageBean.setTurnMessage("The game has ended...") ;
		m.getStartingCup().findNextKal().checkIfWinner();
		if(m.getStartingCup().findNextKal().getOwnerIsWinner()){
			messageBean.setWinnerMessage(nameBean.getPlayer1()+" has won, congratiolations!");
			messageBean.setStandingMessage("The final standing is: "+nameBean.getPlayer1()+" "+m.getStartingCup().findNextKal().getStones()+" - "+ m.getStartingCup().findNextKal().findNextKal().getStones()+" "+nameBean.getPlayer2());
		}
		else if(m.getStartingCup().findNextKal().findNextKal().getOwnerIsWinner()){
			messageBean.setWinnerMessage(nameBean.getPlayer2()+" has won, congratiolations!");
			messageBean.setStandingMessage("The final standing is: "+nameBean.getPlayer1()+" "+m.getStartingCup().findNextKal().getStones()+" - "+ m.getStartingCup().findNextKal().findNextKal().getStones()+" "+nameBean.getPlayer2());
		}
		else {
			messageBean.setWinnerMessage("It is a draw!");
			messageBean.setStandingMessage("The final standing is: "+nameBean.getPlayer1()+" "+m.getStartingCup().findNextKal().getStones()+" - "+ m.getStartingCup().findNextKal().findNextKal().getStones()+" "+nameBean.getPlayer2());
		}		
	}		
  }

package nl.sogyo.mancala;
import java.util.*;

public class Mancala{
	private Cup startingCup;
	private Player startPlayer;
	private int boardSize;
	
	
	public static void main( String[] args ) {	 
    Mancala m = new Mancala(6);
    m.play();
	}
	
	public Mancala(int boardSize) {
		this.boardSize=boardSize;
		setUpBoard();
		
	}
	public void setUpBoard() {
    	startingCup = new Cup(boardSize);
    	startPlayer = startingCup.getOwner();
    }
	
	public void play() {
		Scanner scn = new Scanner(System.in);								
		if (!((Cup)startingCup.findWichKalToCheck().getNeighbour()).checkIfGameEnded()) {
			printBoard(boardSize);
			int turn=1;
			if(!startPlayer.isMyTurn()) {
				turn=2;
			}			
			System.out.println("Player"+turn+": Which Cup do you choose?");			
			int zet = scn.nextInt();			

			if(checkValidMove(zet)){
				((Cup)getNeighbourN(startingCup,zet)).move();
				play();
			}
			
			else {
				System.out.println("Invalid move, please choose one of your Cups");
				play();
			}
			scn.close();
		}
		else {
			startingCup.findNextKal().checkIfWinner();
			printWinnerMessage();						
		}						
	}
	public boolean checkValidMove(int zet) {
		if(zet<boardSize*2+2&&zet>0) 
			if(getNeighbourN(startingCup,zet).getStones()>0) 
				if(getNeighbourN(startingCup,zet).getOwner().isMyTurn()) 
					if(getNeighbourN(startingCup,zet) instanceof Cup) return true;															
					else System.out.println("You should choose a Cup and not a Kalaha");																					
				else System.out.println("You should choose on of your own cups");													
			else System.out.println("You should choose a cup that is not empty");													
		else System.out.println("Your should pick a number between 1 and 13");								
		return false;		
	}
	
    public Cup getStartingCup() {
    	return startingCup;
    }
    
    public Player getStartPlayer() {
    	return startPlayer;
    }
    public int getBoardSize() {
    	return boardSize;
    }
    public void printBoard(int boardSize) {
    	for(int i=boardSize-1;i>=0;i--) {
    		System.out.print("   "+getNeighbourN(startingCup,i+boardSize+1).getStones());
    	}
    	System.out.println("");
    	System.out.println(getNeighbourN(startingCup,2*boardSize+1).getStones()+"                         "+getNeighbourN(startingCup,boardSize).getStones()); 	
    	for(int i=0;i<boardSize;i++) {
    		System.out.print("   "+getNeighbourN(startingCup,i).getStones());
    	}
    	System.out.println("");
    }
    public void printWinnerMessage() {
    	if(startingCup.findNextKal().getOwnerIsWinner()) {
			System.out.println("Player 1 has won, congratiolations!");
		}
		else if(startingCup.findNextKal().findNextKal().getOwnerIsWinner()) {
			System.out.println("Player 2 has won, congratiolations!");
		}
		else {
			System.out.println("The game ended in a draw!");
		}
    }
    public Pit getNeighbourN(Pit pit, int i) {
		if (i == 0) { 
			return pit;
		}
		else {
			i--;
			return getNeighbourN(pit.getNeighbour(), i);
		}
	}
          
}

package nl.sogyo.mancala;

public class Player {

	private boolean isMyTurn ;
	private Player opponent;

	
	public Player(Player opponent_) {	
		opponent = opponent_;	
		isMyTurn = false;
	}		
	
	public Player() {
		opponent = new Player(this);
		isMyTurn = true;
	}
	
	public Player getOpponent() {
		return opponent ;
	}
	
	public boolean isMyTurn() {
		return isMyTurn;
	}
	
	public void changeTurn() {			
		isMyTurn =!isMyTurn;
		if(getOpponent().isMyTurn==isMyTurn) {
			getOpponent().changeTurn();
		}						
	}
}

package nl.sogyo.mancala;

public class Kal extends Pit {
	
	private boolean ownerIsWinner;
	
	public Kal(Player owner_, int count, Cup firstCup,int board) {
		ownerIsWinner=false;
		stones = 0;
		owner=owner_;
		count++;
		if(count==board+1) 
			neighbour=new Cup(owner_.getOpponent(),count,firstCup,board);		
		else neighbour=firstCup;			 
			
						
	}
	
	public void add(int amount) {
		stones += amount;
	}
	public void pass(int stonesGiven) {
		if(stonesGiven>0) {
			if(owner.isMyTurn()) {				
					add();
					neighbour.pass(stonesGiven-1);				
			}
			else {			
					neighbour.pass(stonesGiven);							
			}
		}		
	}
	public void checkIfWinner() {
		if(this.stones>findNextKal().getStones()) {
			this.ownerIsWinner=true;
		}
		else if(this.stones<findNextKal().getStones()) {
			findNextKal().ownerIsWinner=true;
		}		
	}
	
	public boolean getOwnerIsWinner() {
		return ownerIsWinner;
	}	 			
}	

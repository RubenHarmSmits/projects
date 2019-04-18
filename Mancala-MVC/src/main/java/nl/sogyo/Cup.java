package nl.sogyo;
import java.util.*;

public class Cup extends Pit {
			
	public Cup(int board) {
		Player startPlayer= new Player();
		owner=startPlayer;
		stones=4;
		int count=1;
		neighbour= new Cup(startPlayer,count,this,board);	
	}
	
	public Cup(Player owner_, int count, Cup firstCup, int board) {	
		stones=4;
		owner=owner_;
		if(count<board-1||(count>board&&count<2*board)) {					
			count++;
			neighbour = new Cup(owner_,count,firstCup,board);
		}
		else if(count==board-1||count==board*2) {
			count++;
			neighbour = new Kal(owner_,count,firstCup,board);
		}				
	}		
	
	public void move() {					
		if(this.getOwner().isMyTurn()) {		
			if(this.getStones()>0){
				int stonesChosenCup=stones;
				emptyCup();
				neighbour.pass(stonesChosenCup);	
			}								
		}		 										
	}
		
	public void emptyCup() {
		stones = 0;
	}
	public void pass(int stonesGiven) {		
		if (stonesGiven >0) {					
			add();
			neighbour.pass(stonesGiven-1);
			if(stonesGiven==1) {
				checkSteal(this);
				owner.changeTurn();				
			}		
		}		
	}
	public void checkSteal(Cup potentialStealCup) {
		if(potentialStealCup.stones==1&&potentialStealCup.getOwner().isMyTurn()) {
			int count=0;
			countSteps(potentialStealCup,count);
			potentialStealCup.emptyCup();
		}
	}
	
	public void countSteps(Pit countCup,int count) {		
		if(countCup instanceof Cup ) {
			count++;
			countSteps(countCup.getNeighbour(), count);
		}
		else {			
			goOppositeCup(count,countCup);
		}
	}
	
	public void goOppositeCup(int counter, Pit countPit) {
		if(counter==0) {
			passStealStones(countPit.getStones(),countPit, countPit.getOwner());
			countPit.emptyCup();			
		}
		else {
			counter--;
			goOppositeCup(counter, countPit.getNeighbour());
		}
	}
	public void passStealStones(int amountSteal, Pit stealCup, Player ownerStolenCup) {
		if(stealCup.getOwner()!=ownerStolenCup&&stealCup.getOwner()!=stealCup.getNeighbour().getOwner()) {
			stealCup.add(amountSteal+1);
		}
		else {
			passStealStones(amountSteal,stealCup.getNeighbour(),ownerStolenCup);
		}
	}
	public boolean checkIfGameEnded() {
		if (getStones()==0) {
			if(getNeighbour() instanceof Kal) {				
				return true;				
			}
			else {								
				return ((Cup)getNeighbour()).checkIfGameEnded();
			} 			
		}
		else {			
			return false;
		}
	}
}

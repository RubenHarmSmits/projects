package nl.sogyo.mancala;

public abstract class Pit {
	protected int stones;
	protected Player owner;
	protected Pit neighbour;

			
	
	public int getStones() {
		return stones;
	}
	public Player getOwner() {
		return owner;
	}
	public Pit getNeighbour() {
		return neighbour; 
	}
	public void add() {
		stones++;
	}
	public void add(int amount) {
		stones += amount +1;
	}	
	protected abstract void pass(int stones);
		
	public void emptyCup() {
		stones = 0;
	}			
	public Kal findNextKal() {
		if(this.getNeighbour() instanceof Kal) {
			return (Kal)this.getNeighbour();			
		}
		else {
			return this.getNeighbour().findNextKal();
		}
	}
		
	public Kal findWichKalToCheck() {
		if(findNextKal().getOwner().isMyTurn()) {			
			return findNextKal().findNextKal();			
		}
		else {								
			return findNextKal();
		}
	}				
}

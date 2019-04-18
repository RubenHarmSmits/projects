  package nl.sogyo.mancala;

import static org.junit.Assert.*;
import org.junit.Test;

public class MancalaTest {    
	@Test
	public void test14Pitsgemaakt() {
		Mancala m = new Mancala(6);				
		Cup startCup=m.getStartingCup();
		Pit testCup=m.getStartingCup();
		int size = 1;
		while(startCup!=testCup.getNeighbour()) {
			size++;
			testCup=testCup.getNeighbour();
		}
		assertEquals("Het aantal Cups zou 14 moeten zijn",14,size);				
	}
			
	@Test
	public void testSteal() {
		Mancala m = new Mancala(6);
		((Cup)m.getStartingCup().getNeighbour()).move();
		((Cup)getNeighbourN(m.getStartingCup(), 12)).move();		
		((Cup)m.getStartingCup().getNeighbour()).move();
		((Cup)getNeighbourN(m.getStartingCup(), 8)).move();
		assertEquals("het laatste bakje aan de kant van de speler die aan de beurt is zou 0 moeten zijn.",0,m.getStartingCup().getStones());
		assertEquals("De eigen Mancala zou 6 stenen moeten hebben na de steal",7,getNeighbourN(m.getStartingCup(),13).getStones());		
		assertEquals("Het tegenovergestelde bakje zou gestolen en dus leeg moeten zijn",0,getNeighbourN(m.getStartingCup(), 12).getStones());
		assertTrue("De opponent zou nu niet aan de beurt moeten zijn",m.getStartingCup().getOwner().isMyTurn());
		assertFalse("De startplayer zou aan de beurt moeten zijn",m.getStartingCup().getOwner().getOpponent().isMyTurn());
	}
	
	 @Test
	 public void testGeenWinnaar() {
		 Mancala m = new Mancala(6);	 
		 assertFalse("Op het begin zou er geen winnaar moeten zijn" ,m.getStartingCup().checkIfGameEnded());
	    }

	@Test
	public void testIfWinner() {
		Mancala m = new Mancala(6);
		for(int i=0;i<6;i++) {
			((Cup)getNeighbourN(m.getStartingCup(),i)).stones=0;
		}
		assertTrue("Alle Cups zijn leeg aan de kant van startingPlayer dus de game zou over moeten zijn",m.getStartingCup().checkIfGameEnded());
	}
	@Test
	public void testIfWinnerIsOpponent() {
		Mancala m = new Mancala(6);		
		for(int i=7;i<13;i++) {
			((Cup)getNeighbourN(m.getStartingCup(),i)).stones=0;
		}	
		m.getStartPlayer().changeTurn();
		assertTrue("Alle Cups zijn leeg aan de kant van startingPlayer dus de game zou over moeten zijn",((Cup)m.getStartingCup().findWichKalToCheck().getNeighbour()).checkIfGameEnded());
	}
	@Test
	public void testIfWinnerIsCorrect(){
		Mancala m = new Mancala(6);		
		m.getStartingCup().findNextKal().stones=1;		
		m.getStartingCup().findNextKal().checkIfWinner();
		assertTrue("De eerste Kalaha zou moeten hebben gewonnen",m.getStartingCup().findNextKal().getOwnerIsWinner());
		assertFalse("De tweede Kalaha zou moeten hebben verloren",m.getStartingCup().findNextKal().findNextKal().getOwnerIsWinner());
	}
	@Test
	public void testDraw() {
		Mancala m = new Mancala(6);		
		for(int i=0;i<13;i++) {
			getNeighbourN(m.getStartingCup(),i).stones=0;
		}				
		assertFalse("",m.getStartingCup().findNextKal().getOwnerIsWinner());
		assertFalse("",m.getStartingCup().findNextKal().findNextKal().getOwnerIsWinner());
	}
			
	private Pit getNeighbourN(Pit pit, int i) {
		if (i == 0) { 
			return pit;
		}
		else {
			i--;
			return getNeighbourN(pit.getNeighbour(), i);
		}
	}
}

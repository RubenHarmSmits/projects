package nl.sogyo.mancala;
import static org.junit.Assert.*;
import org.junit.Test;

public class CupTest {
	
	@Test
	public void testBeginAmount() {
		Mancala m = new Mancala(6);
		int stones = m.getStartingCup().getStones();	
		assertEquals("The amount of stones should be four",4,stones);					
	}
	@Test
	public void testEmptycup() {
		Mancala m = new Mancala(6);
		m.getStartingCup().emptyCup();
		assertEquals("De cup should have 0 stones after the cup has been emptied",0,m.getStartingCup().getStones());
	}
	@Test
	public void testAdd() {
		Mancala m = new Mancala(6);		
		m.getStartingCup().add();
		assertEquals("De Cup should have 1 stone more than previously",5,m.getStartingCup().getStones());		
	}
	@Test
	public void testHasNeighbour() {
		Mancala m = new Mancala(6);	
		assertNotEquals("The firstcup should have a neighbour",null,m.getStartingCup().getNeighbour());
	}
	@Test
	public void firstCupIsNeighbourOfSecondCup() {
		Mancala m = new Mancala(6);
		m.getStartingCup().add();
		assertEquals("The neighbour of the lastCup should be the firstCup",5,m.getStartingCup().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getNeighbour().getStones());
	}
	@Test
	public void passStones() {
		Mancala m = new Mancala(6);
		m.getStartingCup().pass(3);		
		assertEquals("de cup die net is aangemaakt is en 3 stenen heeft doorgekregen zou er 5 moeten overhouden",5,m.getStartingCup().getStones());					
	}
	@Test
	public void changeTurnIfTurnEnds() {
		Mancala m = new Mancala(6);
		m.getStartingCup().pass(14);		
		assertFalse("Na de eerste zet zou de eerste speler niet meer aan de beurt moeten zijn" ,m.getStartingCup().getOwner().isMyTurn());
		assertTrue("Na de eerste zet zou de tweede speler aan de beurt moeten zijn" ,m.getStartingCup().getOwner().getOpponent().isMyTurn());
	}
	@Test
	public void testBasisZet() {
		Mancala m = new Mancala(6);
		m.getStartingCup().move();		
		assertEquals("De cup die gekozen is zou na de move 0 stenen moeten hebben" ,0,m.getStartingCup().getStones());		
		assertEquals("De buurman van de tweede cup die is gekozen zou nu 6 steentjes moeten hebben",5,m.getStartingCup().getNeighbour().getNeighbour().getStones());
		assertFalse("Na de eerste zet zou de eerste speler niet meer aan de beurt moeten zijn" ,m.getStartingCup().getOwner().isMyTurn());
		assertTrue("Na de eerste zet zou de tweede speler aan de beurt moeten zijn" ,m.getStartingCup().getOwner().getOpponent().isMyTurn());
	}
}
	


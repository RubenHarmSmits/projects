package nl.sogyo.mancala;
import static org.junit.Assert.*;
import org.junit.Test;

public class KalTest {
	@Test
	public void passStonesSkipKalaha() {
		Mancala m = new Mancala(6);
		m.getStartingCup().pass(14);
		assertEquals("De Kalhala van de tegenstander zou moeten zijn overgeslagen en dus zou de eerste Cup 6 steentjes moeten hebben",6,m.getStartingCup().getStones());				
	}	
	
	@Test
	public void lastStoneInOwnPit() {
		Mancala m = new Mancala(6);
		m.getStartingCup().pass(7);
		assertTrue("De beurt is geindigt in de eigen Kalhala, dus het zou weer dezelfde speler zijn beurt moeten zijn",m.getStartingCup().getOwner().isMyTurn());
	}
	
}

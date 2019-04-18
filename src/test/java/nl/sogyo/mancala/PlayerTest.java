package nl.sogyo.mancala;
import static org.junit.Assert.*;
import org.junit.Test;

public class PlayerTest {
	@Test
	public void testIsMyTurn() {
		Player testPlayer = new Player();
		assertTrue("Op het begin zou de eerste Player aan de beurt moeten zijn" ,testPlayer.isMyTurn());	
	}
				
	@Test
	public void testGetOpponent() {
		Player testPlayer = new Player();		
		assertFalse("Op het begin zou de opponent niet aan de beurt moeten zijn", testPlayer.getOpponent().isMyTurn());	
	}
	@Test
	public void testGetOpponentsOpponent() {
		Player testPlayer = new Player();
		assertEquals("Oppenent van opponent is niet des peler zelf",testPlayer,testPlayer.getOpponent().getOpponent());
	}
			
	@Test
	public void changeTurnTest() {
		Player testPlayer = new Player();		
		testPlayer.changeTurn();
		assertFalse("De beurt van Player zou gewisseld moeten zijn",testPlayer.isMyTurn());		
	}
	@Test
	public void changeTurnTestOpponent() {
		Player testPlayer = new Player();
		testPlayer.changeTurn();
		assertFalse("De beurt van de eerste player zou omgedraaid moeten zijn",testPlayer.isMyTurn());
		assertTrue("De beurt van de opponent zou ook omgedraaid moeten zijn",testPlayer.getOpponent().isMyTurn());
	}		
}

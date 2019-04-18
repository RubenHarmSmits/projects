package chess.schaak;

import static org.junit.Assert.*;

import org.junit.Test;


public class KnighTest {

	@Test
	public void testKnightCantGoOnOwnPiece() {
		SchaakApplication test = new SchaakApplication();
		Knight testKnight = (Knight) test.getBoard().getBoxes()[7][6].getPiece();
		
		assertTrue(testKnight.isOnOwnPiece("7664"));
		assertFalse(testKnight.isOnOwnPiece("7655"));
	}
	
	@Test
	public void testIfKNightMoveIsInRange() {
		SchaakApplication test = new SchaakApplication();
		Knight testKnight = (Knight) test.getBoard().getBoxes()[7][6].getPiece();
		
		assertTrue(testKnight.moveIsInRange("7664"));
		assertTrue(testKnight.moveIsInRange("7657"));
		assertFalse(testKnight.moveIsInRange("7656"));
		assertFalse(testKnight.moveIsInRange("7675"));
		assertFalse(testKnight.moveIsInRange("7600"));
	}

}

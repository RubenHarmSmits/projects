package chess.schaak;

import static org.junit.Assert.*;

import org.junit.Test;


public class PonTest {

	@Test
	public void testThatPonCantMove3places() {
		SchaakApplication test = new SchaakApplication();
		
		
		assertTrue(test.checkIfValidMove("6050"));
		assertTrue(test.checkIfValidMove("6040"));
		assertFalse(test.checkIfValidMove("6030"));
		
	}
	@Test
	public void testThatPonCantMove3placesOpposite() {
		SchaakApplication test = new SchaakApplication();
		Piece testPon = test.getBoard().getBoxes()[1][0].getPiece();
		assertTrue(testPon.isValidMove("1020"));
		assertTrue(testPon.isValidMove("1030"));
		assertFalse(testPon.isValidMove("1040"));
	}
	
	@Test
	public void testThatBlackPonGoesInRightDirection() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[1][0].getPiece();
		assertTrue(testPon.isInRightDirection("1020"));
		assertFalse(testPon.isInRightDirection("1000"));
		
	}
	@Test
	public void testThatWhitePonGoesInRightDirection() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[6][0].getPiece();
		assertTrue(testPon.isInRightDirection("6050"));
		assertFalse(testPon.isInRightDirection("6070"));
		
	}
	@Test
	public void testThatPonGoesStraight() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[6][0].getPiece();
		assertTrue(testPon.ponGoesStraight("6000"));
		assertFalse(testPon.ponGoesStraight("6051"));
		
	}
	@Test
	public void testThatPoncaptures() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[6][0].getPiece();
		assertTrue(testPon.checkIfPonCaptures("6007"));
		assertFalse(testPon.checkIfPonCaptures("6050"));
		assertFalse(testPon.checkIfPonCaptures("6061"));		
	}
	
	@Test
	public void testThatPonMakesCaptureMove() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[6][4].getPiece();
		assertTrue(testPon.checkIfPonMakesCaptureMove("6455"));
		assertTrue(testPon.checkIfPonMakesCaptureMove("6453"));
		assertFalse(testPon.checkIfPonMakesCaptureMove("6465"));
		assertFalse(testPon.checkIfPonMakesCaptureMove("6443"));
		assertTrue(testPon.checkIfPonMakesCaptureMove("1021"));
		assertFalse(testPon.checkIfPonMakesCaptureMove("1020"));
	}
	
	@Test
	public void testThatPonCanOnlyMove2BoxesOnFirstMovement() {
		SchaakApplication test = new SchaakApplication();
		Pon testPon = (Pon) test.getBoard().getBoxes()[6][4].getPiece();
		assertTrue(testPon.checkIsValid2Move("6444"));
		assertFalse(testPon.checkIsValid2Move("5434"));
		assertTrue(testPon.checkIsValid2Move("1232"));
		assertFalse(testPon.checkIsValid2Move("2242"));
	}
	
	

}

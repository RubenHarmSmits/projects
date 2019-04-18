package chess.schaak;

import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

//@RunWith(SpringRunner.class)
//@SpringBootTest
public class SchaakApplicationTests {

//	@Test
//	public void contextLoads() {
//	
//	}
	@Test
	public void testBoardSetUp() {
		SchaakApplication test = new SchaakApplication();
		assertTrue("De lengte van het bord zou 8 moten zijn",test.getBoard().getBoxes().length==8);
		assertTrue("De breedte van het bord zou 8 moten zijn" ,test.getBoard().getBoxes()[0].length==8);
		
	}
	@Test
	public void testPiecesSetUp() {
		SchaakApplication test = new SchaakApplication();
		assertEquals(test.getBoard().getBoxes()[6][7].getPiece().getType(),TypePiece.PON);
		assertTrue(test.getBoard().getBoxes()[6][7].getPiece().getColorIsWhite());
		
	}
	
	@Test
	public void testBasicMove() {
		SchaakApplication test = new SchaakApplication();
		assertEquals(test.getBoard().getBoxes()[6][0].getPiece().getType(),TypePiece.PON);
		assertEquals(test.getBoard().getBoxes()[5][0].getPiece().getType(),TypePiece.EMPTY);
		test.move("6050");
		assertEquals(test.getBoard().getBoxes()[6][0].getPiece().getType(),TypePiece.EMPTY);
		assertEquals(test.getBoard().getBoxes()[5][0].getPiece().getType(),TypePiece.PON);
		
	}
	
	@Test
	public void testThatMoveOnPieceIsValid() {
		SchaakApplication test = new SchaakApplication();
		assertTrue(test.checkIfFieldHasAPiece("6050"));
		
	}
	
	@Test
	public void testThatMoveOnEmptyIsInValid() {
		SchaakApplication test = new SchaakApplication();
		assertFalse(test.checkIfFieldHasAPiece("5040"));
		
	}
	
	@Test
	public void testThatMoveOnlyValidIfPlayerTurn() {
		SchaakApplication test = new SchaakApplication();
		assertTrue(test.checkIfValidMove("6050"));
		assertFalse(test.checkIfValidMove("1121"));
	}
	

}


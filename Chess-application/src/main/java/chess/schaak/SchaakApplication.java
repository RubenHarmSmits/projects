package chess.schaak;

import java.util.ArrayList;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class SchaakApplication  {
	
	private Board board;
	private Player whitePlayer;
	private Player blackPlayer;
	private ArrayList<String> moves = new ArrayList<String>();
	private boolean whitesTurn;
	
	
	
	public static void main(String[] args) throws Exception {
		//SpringApplication.run(SchaakApplication.class, args);
//		SchaakApplication game = new SchaakApplication();
//		game.printBoard();
//		game.move("6050");
//		System.out.println(" ");
//		game.printBoard();
		
		System.out.println((int)'1');
		
	}
	
	public SchaakApplication() {
		whitePlayer = new Player(true);
		blackPlayer = new Player(false);
		board = new Board();
		whitesTurn=true;
	}

	public Board getBoard() {
		return board;
	}
	
	
	public void move(String move) {
		System.out.println(move);
		
		if(checkIfValidMove(move)) {
			moves.add(move);

			board.getBoxes()[move.charAt(2)-'0'][move.charAt(3)-'0'].setPiece(board.getBoxes()[move.charAt(0)-'0'][move.charAt(1)-'0'].getPiece());
			
			board.getBoxes()[move.charAt(0)-'0'][move.charAt(1)-'0'].setPiece(new Empty(true));
			whitesTurn=!whitesTurn;
		}
		
	}
	
	public boolean checkIfValidMove(String move) {
		if(!checkIfFieldHasAPiece(move)) return false;
		else if(!checkIfPieceOwnerHasTurn(move))return false;
		else if(!checkIfMoveIsInRules(move))return false;		
		return true;
		
	}
	
	public boolean checkIfMoveIsInRules(String move){
		if(this.board.getBoxes()[move.charAt(0)-'0'][move.charAt(1)-'0'].getPiece().isValidMove(move))return true;
		return false;
	}
	
	public boolean checkIfPieceOwnerHasTurn(String move) {
		if(this.board.getBoxes()[move.charAt(0)-'0'][move.charAt(1)-'0'].getPiece().getColorIsWhite()==whitesTurn) return true;
		return false;
	}
	
	public boolean checkIfFieldHasAPiece(String move) {
		if(this.board.getBoxes()[move.charAt(0)-'0'][move.charAt(1)-'0'].getPiece().getType().equals(TypePiece.EMPTY)) return false;
		return true;
	}
	
	void printBoard() throws Exception{
		
		for(int i=0;i<8;i++) {
			for(int j=0;j<8;j++) {
				if(board.getBoxes()[i][j].getPiece()!=null)System.out.print(board.getBoxes()[i][j].getPiece().getType()+ " ");
			}
			System.out.println("");
		}
		
		 
	}

	

}


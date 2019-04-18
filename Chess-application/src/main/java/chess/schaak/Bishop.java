package chess.schaak;

public class Bishop extends Piece{
	
	public Bishop(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.BISHOP;
		this.board = board;

	}
	public boolean isValidMove(String move) {
		if(validMoveForBishop(move)) return true;
		return false;
	
	}
	
	
}

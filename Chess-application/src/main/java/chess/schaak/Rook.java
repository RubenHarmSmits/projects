package chess.schaak;

public class Rook extends Piece {
	
	public Rook(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.ROOK;
		this.board = board;
	}


	public boolean isValidMove(String move) {
		if(validMoveForRook(move))return true;
		return false;
	}
	
	
}

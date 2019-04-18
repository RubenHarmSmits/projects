package chess.schaak;

public class Queen extends Piece {

	public Queen(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.QUEEN;
		this.board = board;
	}


	public boolean isValidMove(String move) {
		if(validMoveForBishop(move)||validMoveForRook(move))return true;
		return false;
	}
}

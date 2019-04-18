package chess.schaak;

public class King extends Piece {
	
	public King(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.KING;
		this.board = board;
	}



	public boolean isValidMove(String move) {
		if(checkIfMoveOnSelf(move)) return false;
		if(checkIfMoveIsoutOfRange(move)) return false;
		if(isOnOwnPiece(move)) return false;
		return true;
	}
	
	
	
	public boolean checkIfMoveIsoutOfRange(String move) {
		if(this.getChangeX(move)>1)return true;
		if(this.getChangeY(move)>1)return true;
		return false;
		
	}
	
}

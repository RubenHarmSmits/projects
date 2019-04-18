package chess.schaak;

public class Knight extends Piece{
	public Knight(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.KNIGHT;
		this.board = board;
	}

	
	public boolean isValidMove(String move) {
		if(isOnOwnPiece(move))return false;
		if(!moveIsInRange(move))return false;
		return true;
	}
	
	
	public boolean moveIsInRange(String move) {
		if(getChangeY(move)>2||getChangeY(move)<1)return false;
		else if(getChangeX(move)>2||getChangeX(move)<1)return false;
		else if(getChangeY(move)==getChangeX(move))return false;
		return true;
	}
	
	
	
}

package chess.schaak;

public class Empty extends Piece{

	public Empty(boolean isWhite){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.EMPTY;
		
	}

	
	public boolean isValidMove(String move) {
		
		return false;
	}
		
}

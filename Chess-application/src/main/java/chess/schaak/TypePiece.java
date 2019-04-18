package chess.schaak;

public enum TypePiece {
	
	KING, QUEEN, ROOK, BISHOP, KNIGHT, PON, EMPTY,;
	

	
	public String toString() {
		if(this.equals(TypePiece.EMPTY)) return "";
		return super.toString();
	}
	
	
}

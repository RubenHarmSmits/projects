package chess.schaak;

public abstract class Piece {

	protected boolean colorIsWhite;
	protected TypePiece type;
	protected Board board;
	
	
	public int getChangeY(String move) {
		return Math.abs(move.charAt(0)-move.charAt(2));
	}
	public int getChangeX(String move) {
		return Math.abs(move.charAt(1)-move.charAt(3));
	}
	
	public boolean isOnOwnPiece(String move) {		
		boolean otherPieceIsWHite = board.getBoxes()[move.charAt(2)-'0'][move.charAt(3)-'0'].getPiece().getColorIsWhite();
		TypePiece otherPieceType = board.getBoxes()[move.charAt(2)-'0'][move.charAt(3)-'0'].getPiece().getType();
		if(otherPieceIsWHite==this.colorIsWhite&&otherPieceType!=TypePiece.EMPTY)return true;
		return false;
	}
	
	public boolean checkIfMoveOnSelf(String move) {
		if(move.substring(0, 2).equals(move.substring(2,4)))return true;
		return false;
	}
	

	public boolean validMoveForBishop(String move) {
		if(isOnOwnPiece(move))return false;
		if(checkIfMoveOnSelf(move))return false;
		if(!moveIsDiagonal(move))return false;
		if(anyPieceInBetween(move))return false;
		return true;
	}
	
	public boolean validMoveForRook(String move) {
		if(checkIfMoveOnSelf(move))return false;
		if(!checkIfMoveIsHorizontal(move))return false;
		if(checkIfSomeThingInBetween(move))return false;
		if(isOnOwnPiece(move)) return false;
		return true;
	}
	
	public boolean checkIfMoveIsHorizontal(String move) {
		if(this.getChangeX(move)>0&&this.getChangeY(move)>0)return false;
		
		return true;
	}
	
	public boolean checkIfSomeThingInBetween(String move){
		if(getChangeX(move)>0) {
			if(move.charAt(3)>move.charAt(1)) {
				for(int i=move.charAt(1)-'0'+1;i<move.charAt(3)-'0';i++) {
					if(!board.getBoxes()[move.charAt(0)-'0'][i].getPiece().getType().equals(TypePiece.EMPTY))return true;
				}
			}
			else {
				for(int i=move.charAt(1)-'0'-1;i>move.charAt(3)-'0';i--) {
					if(!board.getBoxes()[move.charAt(0)-'0'][i].getPiece().getType().equals(TypePiece.EMPTY))return true;
				}
			}
			
		}
		if(getChangeY(move)>0) {
			if(move.charAt(2)>move.charAt(0)) {
				for(int i=move.charAt(0)-'0'+1;i<move.charAt(2)-'0';i++) {
					if(!board.getBoxes()[i][move.charAt(1)-'0'].getPiece().getType().equals(TypePiece.EMPTY))return true;
				}
			}
			else {
				for(int i=move.charAt(0)-'0'-1;i>move.charAt(2)-'0';i--) {
					if(!board.getBoxes()[i][move.charAt(1)-'0'].getPiece().getType().equals(TypePiece.EMPTY))return true;
				}
			}
		}
		
		
		return false;
	}
	
	public boolean moveIsDiagonal(String move) {
		if(this.getChangeY(move)==this.getChangeX(move)) return true;
		
		return false;
	}
	
	public boolean anyPieceInBetween(String move) {
		
		 if(move.charAt(3)>move.charAt(1)&&move.charAt(2)>move.charAt(0)) {
			 for(int i=1;i<getChangeY(move);i++) {
				 if(!board.getBoxes()[move.charAt(0)-'0'+i][move.charAt(1)-'0'+i].getPiece().getType().equals(TypePiece.EMPTY))return true;
			 }
		 }
		 if(move.charAt(3)>move.charAt(1)&&move.charAt(2)<move.charAt(0)) {
			 for(int i=1;i<getChangeY(move);i++) {
				 if(!board.getBoxes()[move.charAt(0)-'0'-i][move.charAt(1)-'0'+i].getPiece().getType().equals(TypePiece.EMPTY))return true;
			 }
		 }
		 if(move.charAt(3)<move.charAt(1)&&move.charAt(2)<move.charAt(0)) {
			 for(int i=1;i<getChangeY(move);i++) {
				 if(!board.getBoxes()[move.charAt(0)-'0'-i][move.charAt(1)-'0'-i].getPiece().getType().equals(TypePiece.EMPTY))return true;
			 }
		 }
		 if(move.charAt(3)<move.charAt(1)&&move.charAt(2)>move.charAt(0)) {
			 for(int i=1;i<getChangeY(move);i++) {
				 if(!board.getBoxes()[move.charAt(0)-'0'+i][move.charAt(1)-'0'-i].getPiece().getType().equals(TypePiece.EMPTY))return true;
			 }
		 }
		 return false;
		 
		 
	}
	
	
	
	
	public TypePiece getType() {
		return type;
	}

	public boolean getColorIsWhite() {
		return colorIsWhite;
	}
	
	public void setColorIsWhite(boolean isWhite) {
		colorIsWhite = isWhite;
	}
	
	public abstract boolean isValidMove(String move);
	
	




	

}

package chess.schaak;

public class Pon extends Piece{
	
	
	public Pon(boolean isWhite, Board board){
		this.setColorIsWhite(isWhite);
		this.type = TypePiece.PON;
		this.board = board;
	}

	public boolean isValidMove(String move) {
//		if(checkIfDinstanceToBig(move))return false;
//		else if(!isInRightDirection(move))return false;
//		else if(!ponGoesStraight(move)) {
//			if(checkIfPonCaptures(move)&&checkIfPonMakesCaptureMove(move))return true;
//			else return false;
//		}
//		if(getChangeY(move)==2){
//			if(checkIsValid2Move(move)&&!checkIfPonCaptures(move)) return true;
//			return false;
//		}
//				
//		return true;
		
		if(!isInRightDirection(move))return false;
		
		if(checkIfPonCaptures(move)) {
			if(checkIfPonMakesCaptureMove(move)) return true; 
		}
		else {
			if(!ponGoesStraight(move)) return false;
			if(!checkFieldIsEmpty(move)) return false;
			if(getChangeY(move)==1) return true;		
			if(getChangeY(move)==2) {
				if(!checkIsValid2Move(move)) return false;
				if(inBetweenIsEmpty(move)) return true;
			}
		}
		return false;
		
	}
	
	public boolean inBetweenIsEmpty(String move) {
		if(board.getBoxes()[(move.charAt(0)-48+move.charAt(2)-48)/2][move.charAt(3)-48].getPiece().getType()==TypePiece.EMPTY) return true;
		return false;
	}
	
	public boolean checkFieldIsEmpty(String move) {
		if(board.getBoxes()[move.charAt(2)-48][move.charAt(3)-48].getPiece().getType()==TypePiece.EMPTY) return true;
		return false;
				
	}
	
	public boolean checkIsValid2Move(String move) {
		if(move.charAt(0)-48==1||move.charAt(0)-48==6) return true;
		else return false;
		
	}
	
	public boolean checkIfPonMakesCaptureMove(String move) {
		if(getChangeX(move)==1&&getChangeY(move)==1)return true;
		return false;
	}
	
	public boolean checkIfPonCaptures(String move) {
		boolean otherPieceIsWHite = board.getBoxes()[move.charAt(2)-'0'][move.charAt(3)-'0'].getPiece().getColorIsWhite();
		TypePiece otherPieceType = board.getBoxes()[move.charAt(2)-'0'][move.charAt(3)-'0'].getPiece().getType();	
		if(this.getColorIsWhite()!=otherPieceIsWHite&&otherPieceType!=TypePiece.EMPTY) return true;
		return false;
	}
	
	public boolean ponGoesStraight(String move) {
		if(Math.abs(move.charAt(1)-move.charAt(3))>0)return false;
		return true;
	}
	
	public boolean checkIfDinstanceToBig(String move) {
		
		if(Math.abs(move.charAt(0)-move.charAt(2))>2)return true;
		return false;
	}
	
	public boolean isInRightDirection(String move) {
		if(colorIsWhite&&move.charAt(0)>move.charAt(2))return true;
		if(!colorIsWhite&&move.charAt(0)<move.charAt(2))return true;
		return false;
	}
}

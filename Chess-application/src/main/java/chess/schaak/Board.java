package chess.schaak;

public class Board {

	private Box[] boxes[];
	
	
	public Board() {
		boxes = new Box[8][8];
		setUpPieces();
	}


	public Box[][] getBoxes() {
		return boxes;
	}

	public void setUpPieces() {
		for(int i=0;i<8;i++) boxes[6][i]=new Box(new Pon(true, this));
		for(int i=0;i<8;i++) boxes[1][i]=new Box(new Pon(false, this));
		
		boxes[7][0]=new Box(new Rook(true, this));
		boxes[7][1]=new Box(new Knight(true, this));
		boxes[7][2]=new Box(new Bishop(true, this));
		boxes[7][3]=new Box(new Queen(true, this));
		boxes[7][4]=new Box(new King(true, this));
		boxes[7][5]=new Box(new Bishop(true, this));
		boxes[7][6]=new Box(new Knight(true, this));
		boxes[7][7]=new Box(new Rook(true, this));
		
		for(int i=2;i<6;i++) {
			for(int j=0;j<8;j++) boxes[i][j]=new Box(new Empty(true));
		} 
		
		boxes[0][0]=new Box(new Rook(false, this));
		boxes[0][1]=new Box(new Knight(false, this));
		boxes[0][2]=new Box(new Bishop(false, this));
		boxes[0][4]=new Box(new King(false, this));
		boxes[0][3]=new Box(new Queen(false, this));
		boxes[0][5]=new Box(new Bishop(false, this));
		boxes[0][6]=new Box(new Knight(false, this));
		boxes[0][7]=new Box(new Rook(false, this));
		
	}
	
	
	
	
}

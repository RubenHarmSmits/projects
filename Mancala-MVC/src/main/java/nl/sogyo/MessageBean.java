package nl.sogyo;

public class MessageBean{

	private String turnMessage;
	private String moveMessage;
	private String winnerMessage;
	private String standingMessage;

	public String getTurnMessage(){
		return turnMessage;
	}

	public void setTurnMessage(String turnMessage){
		this.turnMessage = turnMessage;
	}

	public String getMoveMessage(){
		return moveMessage;
	}

	public void setMoveMessage(String moveMessage){
		this.moveMessage = moveMessage;
	}
	
	public String getWinnerMessage(){
		return winnerMessage;
	}

	public void setWinnerMessage(String winnerMessage){
		this.winnerMessage = winnerMessage;
	}
	
	public String getStandingMessage(){
		return standingMessage;
	}
	
	public void setStandingMessage(String standingMessage){
		this.standingMessage = standingMessage;
	}
	
	
	

}
using UnityEngine.UI;

public class PlayerScoresPresentation
{
    public delegate void DisplayDelegate(bool visible);

    private DisplayDelegate display;
    private readonly PlayerScoresLogic playerScoresLogic;
    private readonly int pointsToWin;
    private readonly Text scoresText;

    public PlayerScoresPresentation(DisplayDelegate display, PlayerScoresLogic playerScoresLogic, int pointsToWin, Text scoresText)
    {
        this.display = display;
        this.playerScoresLogic = playerScoresLogic;
        this.pointsToWin = pointsToWin;
        this.scoresText = scoresText;
    }

    private string PlayerScoresToString()
    {
        return string.Format("{0} - {1}", playerScoresLogic.PlayerScore(0), playerScoresLogic.PlayerScore(1));
    }

    public void UpdateText()
    {
        if (playerScoresLogic.PlayerScore(0) >= pointsToWin)
            scoresText.text = string.Format("Winner: Player 1 ({0})", PlayerScoresToString());
        else if (playerScoresLogic.PlayerScore(1) >= pointsToWin)
            scoresText.text = string.Format("Winner: Player 2 ({0})", PlayerScoresToString());
        else
            scoresText.text = PlayerScoresToString();
    }

    public void Display(bool visible)
    {
        display(visible);
    }
}

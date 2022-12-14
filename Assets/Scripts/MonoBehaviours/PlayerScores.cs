using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour {

    [Header("Static Data")]
    public PlayerScoresData PlayerScoresData;

    [HideInInspector]
    public PlayerScoresLogic PlayerScoresLogic { get; private set; }
    [HideInInspector]
    public PlayerScoresPresentation PlayerScoresPresentation { get; private set; }

    void Awake()
    {
        const int numPlayers = 2;

        PlayerScoresLogic = new PlayerScoresLogic(numPlayers, PlayerScoresData.PointsToWin);

        Text scoresText = GetComponent<Text>();
        PlayerScoresPresentation = new PlayerScoresPresentation((visible) => gameObject.SetActive(visible), PlayerScoresLogic, PlayerScoresData.PointsToWin, scoresText);

        PlayerScoresLogic.OnScoreChanged += PlayerScoresPresentation.UpdateText;
    }
}

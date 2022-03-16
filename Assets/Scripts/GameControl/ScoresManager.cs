using UnityEngine;

public class ScoresManager
{
    private GameConfig _gameConfig;
    private UiRoot _uiRoot;
    
    public int Scores { get; private set; }

    public ScoresManager(GameConfig gameConfig, UiRoot uiRoot)
    {
        _gameConfig = gameConfig;
        _uiRoot = uiRoot;
    }

    public void AddScore()
    {
        Scores += _gameConfig.MinimumScoresModifier;
        _uiRoot.GetUiItem<ScoresPanel>().SetScoresText(Scores);
    }

    public void ClearScores()
    {
        Scores = 0;
        _uiRoot.GetUiItem<ScoresPanel>().SetScoresText(Scores);
    }
}
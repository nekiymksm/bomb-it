using TMPro;
using UnityEngine;

public class ScoresPanel : UiItem
{
    [SerializeField] private TextMeshProUGUI _scoresText;

    protected override void OnClose()
    {
        GameDirector.ScoresManager.ClearScores();
    }

    public void SetScoresText(int scoresText)
    {
        _scoresText.SetText(scoresText.ToString());
    }
}
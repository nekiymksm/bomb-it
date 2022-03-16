using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : UiItem
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitMenuButton;

    protected override void OnOpen()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitMenuButton.onClick.AddListener(OnExitMenuButtonClick);
    }

    protected override void OnClose()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitMenuButton.onClick.RemoveListener(OnExitMenuButtonClick);
    }
    
    private void OnRestartButtonClick()
    {
        gameObject.SetActive(false);
        GameDirector.Level.RestartLevel();
    }

    private void OnExitMenuButtonClick()
    {
        gameObject.SetActive(false);
        GameDirector.Level.ClearLevel();
        UiRoot.GetUiItem<ScoresPanel>().gameObject.SetActive(false);
        UiRoot.GetUiItem<MainMenu>().gameObject.SetActive(true);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : UiItem
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitMenuButton;

    protected override void OnOpen()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitMenuButton.onClick.AddListener(OnExitMenuButtonClick);
    }

    protected override void OnClose()
    {
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitMenuButton.onClick.RemoveListener(OnExitMenuButtonClick);
    }

    private void OnResumeButtonClick()
    {
        GameDirector.SetPause(false);
        gameObject.SetActive(false);
    }
    
    private void OnRestartButtonClick()
    {
        GameDirector.Level.RestartLevel();
        gameObject.SetActive(false);
    }
    
    private void OnExitMenuButtonClick()
    {
        GameDirector.SetPause(false);
        gameObject.SetActive(false);
        GameDirector.Level.ClearLevel();
        UiRoot.GetUiItem<ScoresPanel>().gameObject.SetActive(false);
        UiRoot.GetUiItem<MainMenu>().gameObject.SetActive(true);
    }
}
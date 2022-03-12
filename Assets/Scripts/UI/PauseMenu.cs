using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : UiItem
{
    [SerializeField] private GameDirector _gameDirector;
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
        _gameDirector.SetPauseActive(false);
    }
    
    private void OnRestartButtonClick()
    {
        _gameDirector.RestartLevel();
    }
    
    private void OnExitMenuButtonClick()
    {
        _gameDirector.LoadMainMenu();
    }
}
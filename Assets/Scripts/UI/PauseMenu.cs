using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : UiItem
{
    [SerializeField] private Level _level;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;

    protected override void OnOpen()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        
        Time.timeScale = 0;
    }

    protected override void OnClose()
    {
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        
        Time.timeScale = 1;
    }

    private void OnResumeButtonClick()
    {
        gameObject.SetActive(false);
    }
    
    private void OnRestartButtonClick()
    {
        gameObject.SetActive(false);
        
        _level.ClearLevel();
        _level.StartLevel();
    }
}
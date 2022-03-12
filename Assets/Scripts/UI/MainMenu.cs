using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UiItem
{
    [SerializeField] private GameDirector _gameDirector;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creatorsButton;
    [SerializeField] private Button _exitButton;

    protected override void OnOpen()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _creatorsButton.onClick.AddListener(OnCreatorsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected override void OnClose()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _creatorsButton.onClick.RemoveListener(OnCreatorsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        gameObject.SetActive(false);
        _gameDirector.RestartLevel();
    }
    
    private void OnCreatorsButtonClick()
    {
        _gameDirector.ShowCreators();
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
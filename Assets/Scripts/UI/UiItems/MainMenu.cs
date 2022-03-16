using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UiItem
{
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
        GameDirector.Level.StartLevel();
        UiRoot.GetUiItem<ScoresPanel>().gameObject.SetActive(true);
    }
    
    private void OnCreatorsButtonClick()
    {
        UiRoot.GetUiItem<CreatorsWindow>().gameObject.SetActive(true);
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
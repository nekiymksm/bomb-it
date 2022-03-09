using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UiItem
{
    [SerializeField] private Level _level;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creatorsButton;
    [SerializeField] private Button _exitButton;

    protected override void OnOpen()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    protected override void OnClose()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        gameObject.SetActive(false);
        
        _level.StartLevel();
    }
}
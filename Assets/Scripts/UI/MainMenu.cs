using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UiItem
{
    [SerializeField] private Level _level;
    [SerializeField] private Button _playButton;

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
        _level.StartLevel();
        gameObject.SetActive(false);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class LevelEndWindow : UiItem
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _exitMenuButton;

    protected override void OnOpen()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _exitMenuButton.onClick.AddListener(OnExitMenuButtonClick);
    }

    protected override void OnClose()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _exitMenuButton.onClick.RemoveListener(OnExitMenuButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        gameObject.SetActive(false);
        GameDirector.SetPause(false);
        GameDirector.Level.ClearLevel();
        GameDirector.Level.StartLevel();
    }

    private void OnExitMenuButtonClick()
    {
        gameObject.SetActive(false);
        GameDirector.SetPause(false);
        GameDirector.Level.ClearLevel();
        UiRoot.GetUiItem<ScoresPanel>().gameObject.SetActive(false);
        UiRoot.GetUiItem<MainMenu>().gameObject.SetActive(true);
    }
}
using UnityEngine;

public class GameItemsDirector : MonoBehaviour
{
    [SerializeField] private UiRoot _uiRoot;
    [SerializeField] private Level _level;

    private void Start()
    {
        _uiRoot.GetUiItem<MainMenu>().gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _level.gameObject.activeSelf)
        {
            _uiRoot.GetUiItem<PauseMenu>().gameObject.SetActive(true);
        }
    }
}
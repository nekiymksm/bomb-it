using UnityEngine;

public class GameItemsDirector : MonoBehaviour
{
    [SerializeField] private UiRoot _uiRoot;

    private MainMenu _mainMenu;

    private void Awake()
    {
        _mainMenu = _uiRoot.GetUiItem<MainMenu>();
    }

    private void Start()
    {
        _mainMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _mainMenu.gameObject.activeSelf == false)
        {
            _uiRoot.GetUiItem<PauseMenu>().gameObject.SetActive(true);
        }
    }
}
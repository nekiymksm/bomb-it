using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private UiRoot _uiRoot;
    
    private MainMenu _mainMenu;
    private PauseMenu _pauseMenu;
    
    public bool GamePaused { get; private set; }

    private void Awake()
    {
        _mainMenu = _uiRoot.GetUiItem<MainMenu>();
        _pauseMenu = _uiRoot.GetUiItem<PauseMenu>();
    }

    private void Start()
    {
        _pauseMenu.Closed += ResumeGame;
        
        _mainMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _mainMenu.gameObject.activeSelf == false)
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
            
        Time.timeScale = 0;
        GamePaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        GamePaused = false;
    }
}
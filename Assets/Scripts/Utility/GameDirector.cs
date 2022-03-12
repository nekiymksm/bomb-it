using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private UiRoot _uiRoot;
    [SerializeField] private Level _level;
    
    private MainMenu _mainMenu;
    private PauseMenu _pauseMenu;
    private CreatorsWindow _creatorsWindow;
    private ScoresPanel _scoresPanel;
    
    public bool GamePaused { get; private set; }

    private void Awake()
    {
        _mainMenu = _uiRoot.GetUiItem<MainMenu>();
        _pauseMenu = _uiRoot.GetUiItem<PauseMenu>();
        _creatorsWindow = _uiRoot.GetUiItem<CreatorsWindow>();
        _scoresPanel = _uiRoot.GetUiItem<ScoresPanel>();
    }

    private void Start()
    {
        LoadMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _mainMenu.gameObject.activeSelf == false)
        {
            SetPauseActive(true);
        }
    }
    
    public void SetPauseActive(bool isPause)
    {
        if (isPause)
        {
            _pauseMenu.gameObject.SetActive(true);
            
            Time.timeScale = 0;
            GamePaused = true;
        }
        else
        {
            _pauseMenu.gameObject.SetActive(false);
            
            Time.timeScale = 1;
            GamePaused = false;
        }
    }

    public void RestartLevel()
    {
        SetPauseActive(false);
        _scoresPanel.gameObject.SetActive(true);
        _level.ClearLevel();
        _level.StartLevel();
    }

    public void LoadMainMenu()
    {
        SetPauseActive(false);
        _scoresPanel.gameObject.SetActive(false);
        _level.ClearLevel();
        _mainMenu.gameObject.SetActive(true);
    }

    public void ShowCreators()
    {
        _creatorsWindow.gameObject.SetActive(true);
    }
}
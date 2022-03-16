using LevelCreation;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private UiRoot _uiRoot;
    [SerializeField] private Level _level;
    
    private MainMenu _mainMenu;
    private PauseMenu _pauseMenu;
    private GameOverWindow _gameOverWindow;

    public ScoresManager ScoresManager { get; private set; }
    public LevelProgressHandler LevelProgressHandler { get; private set; }
    public bool GamePaused { get; private set; }
    
    public Level Level => _level;

    private void Awake()
    {
        ScoresManager = new ScoresManager(_gameConfig, _uiRoot);
        LevelProgressHandler = new LevelProgressHandler(this, _uiRoot);
        
        _mainMenu = _uiRoot.GetUiItem<MainMenu>();
        _pauseMenu = _uiRoot.GetUiItem<PauseMenu>();
        _gameOverWindow = _uiRoot.GetUiItem<GameOverWindow>();
    }

    private void Start()
    {
        _mainMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && _mainMenu.gameObject.activeSelf == false)
        {
            SetPause(true);
            _pauseMenu.gameObject.SetActive(true);
        }
    }
    
    public void SetPause(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0;
            GamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            GamePaused = false;
        }
    }

    public void OverGame()
    {
        _gameOverWindow.gameObject.SetActive(true);
        ScoresManager.ClearScores();
    }
}
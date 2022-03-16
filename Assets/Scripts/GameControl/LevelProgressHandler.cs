public class LevelProgressHandler
{
    private GameDirector _gameDirector;
    private UiRoot _uiRoot;
    private int _killsToWin;

    public LevelProgressHandler(GameDirector gameDirector, UiRoot uiRoot)
    {
        _gameDirector = gameDirector;
        _uiRoot = uiRoot;
    }

    public void CountKill()
    {
        _killsToWin--;

        if (_killsToWin <= 0)
        {
            _gameDirector.SetPause(true);
            _uiRoot.GetUiItem<LevelEndWindow>().gameObject.SetActive(true);
        }
    }
    
    public void SetKillsCount()
    {
        var enemiesPool = _gameDirector.Level.CharactersDirector.Enemies;

        _killsToWin = 0;

        foreach (var enemy in enemiesPool)
        {
            if (enemy.gameObject.activeSelf)
                _killsToWin++;
        }
    }
}
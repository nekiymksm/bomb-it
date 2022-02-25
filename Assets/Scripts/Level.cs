using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Character _playerPrefab;
    [SerializeField] private Character _enemyPrefab;

    private Ground _ground;
    private List<Border> _bordersPool;
    private List<Obstacle> _obstaclesPool;
    private List<SpawnPointer> _spawnPointersPool;
    
    private LevelBuilder _levelBuilder;
    private CharactersSpawner _charactersSpawner;
    private List<SpawnPointer> _spawnPointers;
    private List<Character> _charactersPool;

    private void Awake()
    {
        LoadLevelEnvironments();
        LoadCharacters();
        
        gameObject.SetActive(false);
    }

    public void StartLevel()
    {
        gameObject.SetActive(true);
        
        _levelBuilder = new LevelBuilder();
        _charactersSpawner = new CharactersSpawner();
        
        _levelBuilder.BuildLevel(this, _levelConfig, _ground, _bordersPool, _obstaclesPool, _spawnPointersPool);
        _charactersSpawner.Spawn(_charactersPool, _spawnPointers);
    }

    public void ClearLevel()
    {
        _ground.gameObject.SetActive(false);
        _ground.transform.SetParent(transform);

        RefreshLevelEnvironmentsPool(_bordersPool);
        RefreshLevelEnvironmentsPool(_obstaclesPool);
        RefreshLevelEnvironmentsPool(_spawnPointersPool);

        foreach (var character in _charactersPool)
            character.gameObject.SetActive(false);
    }
    
    public void SetAttributes(List<SpawnPointer> spawnPointers)
    {
        _spawnPointers = spawnPointers;
    }

    private void LoadLevelEnvironments()
    {
        _ground = Instantiate(_levelConfig.GroundPrefab, transform);
        _ground.gameObject.SetActive(false);
        
        _bordersPool = GetLevelEnvironmentsPool(_levelConfig.BorderPrefab, _levelConfig.BordersCount);
        _obstaclesPool = GetLevelEnvironmentsPool(_levelConfig.ObstaclePrefab, 
            _levelConfig.MaxObstaclesInLineCount * (_levelConfig.MaxObstaclesInLineCount / 2));
        _spawnPointersPool = GetLevelEnvironmentsPool(_levelConfig.SpawnPointerPrefab, _levelConfig.MaxObstaclesInLineCount);
    }

    private void LoadCharacters()
    {
        _charactersPool = new List<Character>();
        
        var player = Instantiate(_playerPrefab, transform);
        
        player.gameObject.SetActive(false);
        _charactersPool.Add(player);

        for (int i = 0; i < _levelConfig.MaxObstaclesInLineCount / 2; i++)
        {
            var enemy = Instantiate(_enemyPrefab, transform);
            
            enemy.gameObject.SetActive(false);
            _charactersPool.Add(enemy);
        }
    }

    private List<T> GetLevelEnvironmentsPool<T>(T prefab, int count) where T : LevelEnvironment
    {
        var environments = new List<T>();

        for (int i = 0; i < count; i++)
        {
            environments.Add(Instantiate(prefab, transform));
            environments[i].gameObject.SetActive(false);
        }

        return environments;
    }

    private void RefreshLevelEnvironmentsPool<T>(List<T> itemsPool) where T : LevelEnvironment
    {
        foreach (var item in itemsPool)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(transform);
        }
    }
}
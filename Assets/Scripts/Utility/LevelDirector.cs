using System.Collections.Generic;
using UnityEngine;

public class LevelDirector
{
    private readonly LevelBuilder _levelBuilder = new LevelBuilder();
    private readonly GroundBuilder _groundBuilder = new GroundBuilder();
    private readonly BordersBuilder _bordersBuilder = new BordersBuilder();
    private readonly ObstaclesBuilder _obstaclesBuilder = new ObstaclesBuilder();
    private readonly SpawnPointersBuilder _spawnPointersBuilder = new SpawnPointersBuilder();

    public Level Level { get; }
    public LevelConfig LevelConfig { get; }
    
    public Ground Ground { get; private set; }
    public ItemsPool Borders { get; private set; }
    public ItemsPool Obstacles { get; private set; }
    public ItemsPool SpawnPointersPool { get; private set; }
    
    public int HorizontalSize { get; set; }
    public int VerticalSize { get; set; }
    public float LevelLength { get; set; }
    public float LevelWidth { get; set; }
    public List<SpawnPointer> SpawnPointers { get; set; }

    public LevelDirector(Level level, LevelConfig levelConfig)
    {
        Level = level;
        LevelConfig = levelConfig;
        
        _levelBuilder.Successor = _groundBuilder;
        _groundBuilder.Successor = _bordersBuilder;
        _bordersBuilder.Successor = _obstaclesBuilder;
        _obstaclesBuilder.Successor = _spawnPointersBuilder;
    }

    public void LoadItems()
    {
        Ground = Object.Instantiate(LevelConfig.GroundPrefab, Level.transform);
        Ground.gameObject.SetActive(false);
        
        Borders = new ItemsPool();
        Obstacles = new ItemsPool();
        SpawnPointersPool = new ItemsPool();
        
        Borders.LoadItemsPool(LevelConfig.BorderPrefab.gameObject, Level.transform, LevelConfig.BordersCount);
        
        Obstacles.LoadItemsPool(LevelConfig.ObstaclePrefab.gameObject, Level.transform, 
            LevelConfig.MaxObstaclesInLineCount * (LevelConfig.MaxObstaclesInLineCount / 2));
        
        SpawnPointersPool.LoadItemsPool(LevelConfig.SpawnPointerPrefab.gameObject, Level.transform, 
            LevelConfig.MaxObstaclesInLineCount);
    }
    
    public void AssembleLevel()
    {
        _levelBuilder.Build(this);
    }

    public void RefreshLevelItems()
    {
        Borders.RefreshItemsPool();
        Obstacles.RefreshItemsPool();
        SpawnPointersPool.RefreshItemsPool();
    }
}
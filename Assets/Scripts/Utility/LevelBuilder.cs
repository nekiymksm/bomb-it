using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder
{
    private Level _level;
    private LevelConfig _levelConfig;
    private Ground _ground;
    private List<Border> _bordersPool;
    private List<Obstacle> _obstaclesPool;
    private List<SpawnPointer> _spawnPointersPool;

    private int _horizontalObstaclesGridSize;
    private int _verticalObstaclesGridSize;
    private float _levelLength;
    private float _levelWidth;
    private List<SpawnPointer> _spawnPointers;

    public void BuildLevel(Level level, LevelConfig levelConfig, Ground ground, List<Border> borders, 
        List<Obstacle> obstacles, List<SpawnPointer> spawnPointers)
    {
        _level = level;
        _levelConfig = levelConfig;
        _ground = ground;
        _bordersPool = borders;
        _obstaclesPool = obstacles;
        _spawnPointersPool = spawnPointers;
        
        SetObstaclesGridSize();
        SetGround();
        SetLevelBorders();
        SetObstaclesGrid();
        SetSpawnPointers();
        
        _level.SetAttributes(_spawnPointers);
    }
    
    private void SetObstaclesGridSize()
    {
        _horizontalObstaclesGridSize = Random.Range(_levelConfig.MinObstaclesInLineCount, _levelConfig.MaxObstaclesInLineCount);
        _verticalObstaclesGridSize = Random.Range(_levelConfig.MinObstaclesInLineCount, _levelConfig.MaxObstaclesInLineCount);
    
        if (_verticalObstaclesGridSize > _horizontalObstaclesGridSize / 2)
            _verticalObstaclesGridSize = _horizontalObstaclesGridSize / 2;
    }
    
    private void SetGround()
    {
        _levelLength = _horizontalObstaclesGridSize * _levelConfig.PassWidth;
        _levelWidth = _verticalObstaclesGridSize * _levelConfig.PassWidth;
        
        _ground.gameObject.SetActive(true);
        _ground.transform.localScale = new Vector3(_levelLength + _levelConfig.GroundPrefab.transform.localScale.x, 
            _levelConfig.GroundPrefab.transform.localScale.y, _levelWidth + _levelConfig.GroundPrefab.transform.localScale.z);
        _ground.transform.SetParent(_level.transform);
    }
    
    private void SetLevelBorders()
    {
        float obstaclePrefabXScale = _levelConfig.ObstaclePrefab.transform.localScale.x;
        float obstaclePrefabZScale = _levelConfig.ObstaclePrefab.transform.localScale.z;
        
        SetBorder(0, _levelWidth / 2 + obstaclePrefabZScale,
            _levelLength + _levelConfig.PassWidth, obstaclePrefabZScale);
        
        SetBorder(0, -_levelWidth / 2 - _levelConfig.PassWidth + obstaclePrefabZScale,
            _levelLength + _levelConfig.PassWidth, obstaclePrefabZScale);
        
        SetBorder(_levelLength / 2 + obstaclePrefabXScale, 0,
            obstaclePrefabXScale, _levelWidth + _levelConfig.PassWidth);
        
        SetBorder(-_levelLength / 2 - _levelConfig.PassWidth + obstaclePrefabXScale, 0,
            obstaclePrefabXScale, _levelWidth + _levelConfig.PassWidth);
    }
    
    private void SetObstaclesGrid()
    {
        for (int i = 0; i < _verticalObstaclesGridSize; i++)
        {
            float verticalGridPointer = 
                _levelWidth / 2 - _levelConfig.ObstaclePrefab.transform.localScale.z - i * _levelConfig.PassWidth;
            
            for (int j = 0; j < _horizontalObstaclesGridSize; j++)
            {
                var obstacle = GetEnvironment(_obstaclesPool);
                float horizontalGridPointer = 
                    _levelLength / 2 - _levelConfig.ObstaclePrefab.transform.localScale.x - j * _levelConfig.PassWidth;

                obstacle.transform.position = new Vector3(horizontalGridPointer, 0, verticalGridPointer);
                obstacle.transform.SetParent(_ground.transform);
            }
        }
    }
    
    private void SetSpawnPointers()
    {
        _spawnPointers = new List<SpawnPointer>();
        
        float obstaclesCountInLine = _horizontalObstaclesGridSize / 2;
        float xAxisPointersModifier = _levelLength / obstaclesCountInLine;
        float xAxisLengthIndent = _levelLength / 2 / xAxisPointersModifier;
    
        for (int i = 0; i < _levelConfig.SpawnPointersColumnsCount; i++)
        {
            float zAxisSpawnPointer = _levelWidth / 2 - i * _levelWidth;
            
            for (int j = 0; j < obstaclesCountInLine; j++)
            {
                var spawnPointer = GetEnvironment(_spawnPointersPool);
                float xAxisSpawnPointer = _levelLength / 2 - xAxisLengthIndent - j * xAxisPointersModifier;
                
                spawnPointer.transform.position = new Vector3(xAxisSpawnPointer, 0, zAxisSpawnPointer);
                _spawnPointers.Add(spawnPointer);
                spawnPointer.transform.SetParent(_level.transform);
            }
        }
    }
    
    private void SetBorder(float xPosition, float zPosition, float xScale, float zScale)
    {
        Border border = GetEnvironment(_bordersPool);

        border.transform.position = new Vector3(xPosition, 0, zPosition);
        border.transform.localScale = new Vector3(xScale, border.transform.localScale.y, zScale);
        border.transform.SetParent(_ground.transform);
    }
    
    private T GetEnvironment<T>(List<T> environmentsPool) where T : LevelEnvironment
    {
        foreach (var environment in environmentsPool)
        {
            if (environment.gameObject.activeSelf == false)
            {
                environment.gameObject.SetActive(true);
                
                return environment;
            }
        }

        return null;
    }
}
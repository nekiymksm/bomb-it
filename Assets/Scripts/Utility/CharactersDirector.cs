using System.Collections.Generic;
using UnityEngine;

public class CharactersDirector
{
    private Level _level;
    private LevelConfig _levelConfig;
    private List<Character> _characters;
    private List<SpawnPointer> _spawnPointers;
    
    public Player Player { get; private set; }

    public CharactersDirector(Level level, LevelConfig levelConfig)
    {
        _level = level;
        _levelConfig = levelConfig;
    }
    
    public void LoadCharacters()
    {
        _characters = new List<Character>();
        
        Player = Object.Instantiate(_levelConfig.PlayerPrefab, _level.transform);
        
        Player.gameObject.SetActive(false);
        _characters.Add(Player);

        for (int i = 0; i < _levelConfig.MaxObstaclesInLineCount / 2; i++)
        {
            var enemy = Object.Instantiate(_levelConfig.EnemyPrefab, _level.transform);
            
            enemy.gameObject.SetActive(false);
            _characters.Add(enemy);
        }
    }
    
    public void SpawnCharacters(List<SpawnPointer> spawnPointers)
    {
        foreach (var character in _characters)
            character.gameObject.SetActive(false);
        
        _spawnPointers = spawnPointers;

        for (int i = 0; i < _spawnPointers.Count / 2 + 1; i++)
        {
            var spawnPointer = TryGetSpawnPoint();

            _characters[i].transform.position = spawnPointer.transform.position;
            _characters[i].gameObject.SetActive(true);
            spawnPointer.gameObject.SetActive(false);
        }
    }

    public void ResetCharacters()
    {
        foreach (var character in _characters)
        {
            character.transform.rotation = _levelConfig.PlayerPrefab.transform.rotation;
        }
    }
    
    private SpawnPointer TryGetSpawnPoint()
    {
        foreach (var spawnPointer in _spawnPointers)
        {
            if (spawnPointer.gameObject.activeSelf)
                return spawnPointer;
        }
    
        return null;
    }
}
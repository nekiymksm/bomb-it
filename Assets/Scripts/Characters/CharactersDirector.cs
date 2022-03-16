using System.Collections.Generic;
using LevelCreation;
using UnityEngine;

public class CharactersDirector
{
    private Level _level;
    private LevelConfig _levelConfig;

    public Player Player { get; private set; }
    public List<Enemy> Enemies { get; private set; }

    public CharactersDirector(Level level, LevelConfig levelConfig)
    {
        _level = level;
        _levelConfig = levelConfig;
    }
    
    public void LoadCharacters()
    {
        Player = Object.Instantiate(_levelConfig.PlayerPrefab, _level.transform);
        Player.gameObject.SetActive(false);
        
        Enemies = new List<Enemy>();

        for (int i = 0; i < _levelConfig.MaxObstaclesInLineCount / 2; i++)
        {
            Enemies.Add(Object.Instantiate(_levelConfig.EnemyPrefab, _level.transform));
            Enemies[i].gameObject.SetActive(false);
        }
    }
    
    public void SpawnCharacters(List<SpawnPointer> spawnPointers)
    {
        SetCharacterPosition(Player, spawnPointers[0]);
        
        for (int i = 1; i < spawnPointers.Count / 2; i++)
            SetCharacterPosition(Enemies[i], spawnPointers[i]);
    }

    public void ResetCharacters()
    {
        Player.transform.rotation = _levelConfig.PlayerPrefab.transform.rotation;
        Player.gameObject.SetActive(false);
        
        foreach (var enemy in Enemies)
        {
            enemy.transform.rotation = _levelConfig.EnemyPrefab.transform.rotation;
            enemy.gameObject.SetActive(false);
        }
    }

    private void SetCharacterPosition(Character character, SpawnPointer positionPointer)
    {
        character.transform.position = positionPointer.transform.position;
        character.gameObject.SetActive(true);
        positionPointer.gameObject.SetActive(false);
    }
}
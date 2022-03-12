using System;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    
    private NavMeshSurface _navMeshSurface;
    
    public LevelItemsDirector LevelItemsDirector { get; private set; }
    public CharactersDirector CharactersDirector { get; private set; }

    public event Action LevelStarted;

    private void Awake()
    {
        LevelItemsDirector = new LevelItemsDirector(this, _levelConfig);
        CharactersDirector = new CharactersDirector(this, _levelConfig);
        
        LevelItemsDirector.LoadItems();
        CharactersDirector.LoadCharacters();

        _navMeshSurface = LevelItemsDirector.Ground.GetComponent<NavMeshSurface>();
    }

    public void StartLevel()
    {
        gameObject.SetActive(true);
        
        LevelItemsDirector.AssembleLevel();
        _navMeshSurface.BuildNavMesh();
        CharactersDirector.SpawnCharacters(LevelItemsDirector.SpawnPointers);

        LevelStarted?.Invoke();
    }

    public void ClearLevel()
    {
        LevelItemsDirector.Ground.gameObject.SetActive(false);
        LevelItemsDirector.Ground.transform.SetParent(transform);
        LevelItemsDirector.RefreshLevelItems();
        CharactersDirector.ResetCharacters();
    }
}
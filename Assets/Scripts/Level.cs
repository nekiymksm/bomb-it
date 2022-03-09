using System;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    
    private NavMeshSurface _navMeshSurface;
    
    public LevelDirector LevelDirector { get; private set; }
    public CharactersDirector CharactersDirector { get; private set; }

    public event Action LevelStarted;

    private void Awake()
    {
        LevelDirector = new LevelDirector(this, _levelConfig);
        CharactersDirector = new CharactersDirector(this, _levelConfig);
        
        LevelDirector.LoadItems();
        CharactersDirector.LoadCharacters();

        _navMeshSurface = LevelDirector.Ground.GetComponent<NavMeshSurface>();
    }

    public void StartLevel()
    {
        gameObject.SetActive(true);
        
        LevelDirector.AssembleLevel();
        _navMeshSurface.BuildNavMesh();
        CharactersDirector.SpawnCharacters(LevelDirector.SpawnPointers);

        LevelStarted?.Invoke();
    }

    public void ClearLevel()
    {
        LevelDirector.Ground.gameObject.SetActive(false);
        LevelDirector.Ground.transform.SetParent(transform);
        LevelDirector.RefreshLevelItems();
        CharactersDirector.ResetCharacters();
    }
}
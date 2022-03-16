using System;
using UnityEngine;
using UnityEngine.AI;

namespace LevelCreation
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameDirector _gameDirector;
        [SerializeField] private LevelConfig _levelConfig;

        private NavMeshSurface _navMeshSurface;

        public GameDirector GameDirector => _gameDirector;

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

            _gameDirector.LevelProgressHandler.SetKillsCount();
            LevelStarted?.Invoke();
        }

        public void ClearLevel()
        {
            LevelItemsDirector.Ground.gameObject.SetActive(false);
            LevelItemsDirector.RefreshLevelItems();
            CharactersDirector.ResetCharacters();
        }
        
        public void RestartLevel()
        {
            ClearLevel();
            StartLevel();
            _gameDirector.SetPause(false);
            _gameDirector.ScoresManager.ClearScores();
        }
    }
}
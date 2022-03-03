using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "GameConfigs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Character _enemyPrefab;
    [SerializeField] private Ground _groundPrefab;
    [SerializeField] private Border _borderPrefab;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private SpawnPointer _spawnPointerPrefab;
    [SerializeField] private int _bordersCount;
    [SerializeField] private int _maxObstaclesInLineCount;
    [SerializeField] private int _minObstaclesInLineCount;
    [SerializeField] private int _spawnPointersColumnsCount;
    [SerializeField] private int _passWidth;

    public Player PlayerPrefab => _playerPrefab;
    public Character EnemyPrefab => _enemyPrefab;
    public Ground GroundPrefab => _groundPrefab;
    public Border BorderPrefab => _borderPrefab;
    public Obstacle ObstaclePrefab => _obstaclePrefab;
    public SpawnPointer SpawnPointerPrefab => _spawnPointerPrefab;
    public int BordersCount => _bordersCount;
    public int MaxObstaclesInLineCount => _maxObstaclesInLineCount;
    public int MinObstaclesInLineCount => _minObstaclesInLineCount;
    public int SpawnPointersColumnsCount => _spawnPointersColumnsCount;
    public int PassWidth => _passWidth;
}
using System.Collections.Generic;

public class LevelAssembler
{
    private LevelBuilder _levelBuilder;
    private GroundBuilder _groundBuilder;
    private BordersBuilder _bordersBuilder;
    private ObstaclesBuilder _obstaclesBuilder;
    private SpawnPointersBuilder _spawnPointersBuilder;

    private Level _level;
    private LevelConfig _levelConfig;
    private Ground _ground;
    private List<Border> _bordersPool;
    private List<Obstacle> _obstaclesPool;
    private List<SpawnPointer> _spawnPointersPool;

    public int HorizontalLevelSize { get; set; }
    public int VerticalLevelSize { get; set; }
    public float GroundLength { get; set; }
    public float GroundWidth { get; set; }

    public Level Level => _level;
    public LevelConfig LevelConfig => _levelConfig;
    public Ground Ground => _ground;
    public List<Border> BordersPool => _bordersPool;
    public List<Obstacle> ObstaclesPool => _obstaclesPool;
    public List<SpawnPointer> SpawnPointersPool => _spawnPointersPool;

    public LevelAssembler()
    {
        _levelBuilder = new LevelBuilder();
        _groundBuilder = new GroundBuilder();
        _bordersBuilder = new BordersBuilder();
        _obstaclesBuilder = new ObstaclesBuilder();
        _spawnPointersBuilder = new SpawnPointersBuilder();

        _levelBuilder.Successor = _groundBuilder;
        _groundBuilder.Successor = _bordersBuilder;
        _bordersBuilder.Successor = _obstaclesBuilder;
        _obstaclesBuilder.Successor = _spawnPointersBuilder;
    }

    public void Assemble(Level level, LevelConfig levelConfig, Ground ground, List<Border> bordersPool, 
        List<Obstacle> obstaclesPool, List<SpawnPointer> spawnPointersPool)
    {
        _level = level;
        _levelConfig = levelConfig;
        _ground = ground;
        _bordersPool = bordersPool;
        _obstaclesPool = obstaclesPool;
        _spawnPointersPool = spawnPointersPool;
        
        _levelBuilder.Build(this);
    }
}
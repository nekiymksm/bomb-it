using System.Collections.Generic;

public class LevelAssembler
{
    private LevelBuilder _levelBuilder = new LevelBuilder();
    private GroundBuilder _groundBuilder = new GroundBuilder();
    private BordersBuilder _bordersBuilder = new BordersBuilder();
    private ObstaclesBuilder _obstaclesBuilder = new ObstaclesBuilder();
    private SpawnPointersBuilder _spawnPointersBuilder = new SpawnPointersBuilder();

    public int HorizontalLevelSize { get; set; }
    public int VerticalLevelSize { get; set; }
    public float GroundLength { get; set; }
    public float GroundWidth { get; set; }

    public Level Level { get; private set; }
    public LevelConfig LevelConfig { get; private set; }
    public Ground Ground { get; private set; }
    public List<Border> BordersPool { get; private set; }
    public List<Obstacle> ObstaclesPool { get; private set; }
    public List<SpawnPointer> SpawnPointersPool { get; private set; }

    public LevelAssembler()
    {
        _levelBuilder.Successor = _groundBuilder;
        _groundBuilder.Successor = _bordersBuilder;
        _bordersBuilder.Successor = _obstaclesBuilder;
        _obstaclesBuilder.Successor = _spawnPointersBuilder;
    }

    public void Assemble(Level level, LevelConfig levelConfig, Ground ground, List<Border> bordersPool, 
        List<Obstacle> obstaclesPool, List<SpawnPointer> spawnPointersPool)
    {
        Level = level;
        LevelConfig = levelConfig;
        Ground = ground;
        BordersPool = bordersPool;
        ObstaclesPool = obstaclesPool;
        SpawnPointersPool = spawnPointersPool;
        
        _levelBuilder.Build(this);
    }
}
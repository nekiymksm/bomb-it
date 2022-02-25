using UnityEngine;

public class LevelBuilder : Builder
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetLevelSize(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }
    
    private void SetLevelSize(LevelAssembler levelAssembler)
    {
        levelAssembler.HorizontalLevelSize = Random.Range(levelAssembler.LevelConfig.MinObstaclesInLineCount, 
            levelAssembler.LevelConfig.MaxObstaclesInLineCount);
        levelAssembler.VerticalLevelSize = Random.Range(levelAssembler.LevelConfig.MinObstaclesInLineCount, 
            levelAssembler.LevelConfig.MaxObstaclesInLineCount);
    
        if (levelAssembler.VerticalLevelSize > levelAssembler.HorizontalLevelSize / 2)
            levelAssembler.VerticalLevelSize = levelAssembler.HorizontalLevelSize / 2;
    }
}
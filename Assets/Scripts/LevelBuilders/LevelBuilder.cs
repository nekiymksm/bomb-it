using UnityEngine;

public class LevelBuilder : Builder
{
    public override void Build(LevelDirector levelDirector)
    {
        SetLevelSize(levelDirector);
        
        if (Successor != null)
            Successor.Build(levelDirector);
    }
    
    private void SetLevelSize(LevelDirector levelDirector)
    {
        levelDirector.HorizontalSize = Random.Range(levelDirector.LevelConfig.MinObstaclesInLineCount, 
            levelDirector.LevelConfig.MaxObstaclesInLineCount);
        levelDirector.VerticalSize = Random.Range(levelDirector.LevelConfig.MinObstaclesInLineCount, 
            levelDirector.LevelConfig.MaxObstaclesInLineCount);
    
        if (levelDirector.VerticalSize > levelDirector.HorizontalSize / 2)
            levelDirector.VerticalSize = levelDirector.HorizontalSize / 2;
    }
}
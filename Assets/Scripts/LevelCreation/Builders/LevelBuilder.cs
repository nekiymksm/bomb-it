using UnityEngine;

public class LevelBuilder : Builder
{
    public override void Build(LevelItemsDirector levelItemsDirector)
    {
        SetLevelSize(levelItemsDirector);
        
        if (Successor != null)
            Successor.Build(levelItemsDirector);
    }
    
    private void SetLevelSize(LevelItemsDirector levelItemsDirector)
    {
        levelItemsDirector.HorizontalSize = Random.Range(levelItemsDirector.LevelConfig.MinObstaclesInLineCount, 
            levelItemsDirector.LevelConfig.MaxObstaclesInLineCount);
        levelItemsDirector.VerticalSize = Random.Range(levelItemsDirector.LevelConfig.MinObstaclesInLineCount, 
            levelItemsDirector.LevelConfig.MaxObstaclesInLineCount);
    
        if (levelItemsDirector.VerticalSize > levelItemsDirector.HorizontalSize / 2)
            levelItemsDirector.VerticalSize = levelItemsDirector.HorizontalSize / 2;
    }
}
using UnityEngine;

public class ObstaclesBuilder : Builder 
{
    public override void Build(LevelItemsDirector levelItemsDirector)
    {
        SetObstacles(levelItemsDirector);
        
        if (Successor != null)
            Successor.Build(levelItemsDirector);
    }

    private void SetObstacles(LevelItemsDirector levelItemsDirector)
    {
        for (int i = 0; i < levelItemsDirector.VerticalSize; i++)
        {
            float verticalPointer = 
                levelItemsDirector.LevelWidth / 2 - levelItemsDirector.LevelConfig.ObstaclePrefab.transform.localScale.z 
                                               - i * levelItemsDirector.LevelConfig.PassWidth;
            
            for (int j = 0; j < levelItemsDirector.HorizontalSize; j++)
            {
                float horizontalPointer = 
                    levelItemsDirector.LevelLength / 2 - levelItemsDirector.LevelConfig.ObstaclePrefab.transform.localScale.x 
                                                    - j * levelItemsDirector.LevelConfig.PassWidth;
                
                var obstacle = levelItemsDirector.Obstacles.TryGetItem();

                obstacle.transform.position = new Vector3(horizontalPointer, 0, verticalPointer);
                obstacle.transform.SetParent(levelItemsDirector.Ground.transform);
            }
        }
    }
}
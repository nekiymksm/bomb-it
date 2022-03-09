using UnityEngine;

public class ObstaclesBuilder : Builder 
{
    public override void Build(LevelDirector levelDirector)
    {
        SetObstacles(levelDirector);
        
        if (Successor != null)
            Successor.Build(levelDirector);
    }

    private void SetObstacles(LevelDirector levelDirector)
    {
        for (int i = 0; i < levelDirector.VerticalSize; i++)
        {
            float verticalPointer = 
                levelDirector.LevelWidth / 2 - levelDirector.LevelConfig.ObstaclePrefab.transform.localScale.z 
                                               - i * levelDirector.LevelConfig.PassWidth;
            
            for (int j = 0; j < levelDirector.HorizontalSize; j++)
            {
                float horizontalPointer = 
                    levelDirector.LevelLength / 2 - levelDirector.LevelConfig.ObstaclePrefab.transform.localScale.x 
                                                    - j * levelDirector.LevelConfig.PassWidth;
                
                var obstacle = levelDirector.Obstacles.TryGetItem();

                obstacle.transform.position = new Vector3(horizontalPointer, 0, verticalPointer);
                obstacle.transform.SetParent(levelDirector.Ground.transform);
            }
        }
    }
}
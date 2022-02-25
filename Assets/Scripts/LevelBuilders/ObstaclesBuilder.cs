using UnityEngine;

public class ObstaclesBuilder : Builder 
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetObstacles(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }

    private void SetObstacles(LevelAssembler levelAssembler)
    {
        for (int i = 0; i < levelAssembler.VerticalLevelSize; i++)
        {
            float verticalPointer = 
                levelAssembler.GroundWidth / 2 - levelAssembler.LevelConfig.ObstaclePrefab.transform.localScale.z 
                                               - i * levelAssembler.LevelConfig.PassWidth;
            
            for (int j = 0; j < levelAssembler.HorizontalLevelSize; j++)
            {
                float horizontalPointer = 
                    levelAssembler.GroundLength / 2 - levelAssembler.LevelConfig.ObstaclePrefab.transform.localScale.x 
                                                    - j * levelAssembler.LevelConfig.PassWidth;
                
                var obstacle = GetLevelItem(levelAssembler.ObstaclesPool);

                obstacle.transform.position = new Vector3(horizontalPointer, 0, verticalPointer);
                obstacle.transform.SetParent(levelAssembler.Ground.transform);
            }
        }
    }
}
using UnityEngine;

public class BordersBuilder : Builder
{
    public override void Build(LevelItemsDirector levelItemsDirector)
    {
        SetBorders(levelItemsDirector);
        
        if (Successor != null)
            Successor.Build(levelItemsDirector);
    }

    private void SetBorders(LevelItemsDirector levelItemsDirector)
    {
        var directionAngle = 360 * Mathf.Deg2Rad;
        var levelConfig = levelItemsDirector.LevelConfig;
        
        for (int i = 0; i < levelConfig.BordersCount; i++)
        {
            var border = levelItemsDirector.Borders.TryGetItem();

            var xAxisDirection = Mathf.Cos(directionAngle / levelConfig.BordersCount * i);
            var zAxisDirection = Mathf.Sin(directionAngle / levelConfig.BordersCount * i);
            
            var position = new Vector3();
            
            position.y = 0;
            position.x = (levelItemsDirector.LevelLength / 2 + levelConfig.ObstaclePrefab.transform.localScale.x) * xAxisDirection;
            position.z = (levelItemsDirector.LevelWidth / 2 + levelConfig.ObstaclePrefab.transform.localScale.z) * zAxisDirection;

            var scale = new Vector3();
            
            scale.y = levelConfig.BorderPrefab.transform.localScale.y;
            scale.x = (levelItemsDirector.LevelLength + levelConfig.PassWidth) * Mathf.Abs(zAxisDirection) +
                levelConfig.BorderPrefab.transform.localScale.z;
            scale.z = (levelItemsDirector.LevelWidth + levelConfig.PassWidth) * Mathf.Abs(xAxisDirection) + 
                      levelConfig.BorderPrefab.transform.localScale.x;
            
            border.transform.position = position;
            border.transform.localScale = scale;
            border.transform.SetParent(levelItemsDirector.Ground.transform);
        }
    }
}
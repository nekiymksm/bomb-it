using UnityEngine;

public class BordersBuilder : Builder
{
    public override void Build(LevelDirector levelDirector)
    {
        SetBorders(levelDirector);
        
        if (Successor != null)
            Successor.Build(levelDirector);
    }

    private void SetBorders(LevelDirector levelDirector)
    {
        var directionAngle = 360 * Mathf.Deg2Rad;
        var levelConfig = levelDirector.LevelConfig;
        
        for (int i = 0; i < levelConfig.BordersCount; i++)
        {
            var border = levelDirector.Borders.TryGetItem();

            var xAxisDirection = Mathf.Cos(directionAngle / levelConfig.BordersCount * i);
            var zAxisDirection = Mathf.Sin(directionAngle / levelConfig.BordersCount * i);
            
            var position = new Vector3();
            
            position.y = 0;
            position.x = (levelDirector.LevelLength / 2 + levelConfig.ObstaclePrefab.transform.localScale.x) * xAxisDirection;
            position.z = (levelDirector.LevelWidth / 2 + levelConfig.ObstaclePrefab.transform.localScale.z) * zAxisDirection;

            var scale = new Vector3();
            
            scale.y = levelConfig.BorderPrefab.transform.localScale.y;
            scale.x = (levelDirector.LevelLength + levelConfig.PassWidth) * Mathf.Abs(zAxisDirection) +
                levelConfig.BorderPrefab.transform.localScale.z;
            scale.z = (levelDirector.LevelWidth + levelConfig.PassWidth) * Mathf.Abs(xAxisDirection) + 
                      levelConfig.BorderPrefab.transform.localScale.x;
            
            border.transform.position = position;
            border.transform.localScale = scale;
            border.transform.SetParent(levelDirector.Ground.transform);
        }
    }
}
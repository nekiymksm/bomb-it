using UnityEngine;

public class BordersBuilder : Builder
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetBorders(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }

    private void SetBorders(LevelAssembler levelAssembler)
    {
        var directionAngle = 360 * Mathf.Deg2Rad;
        var levelConfig = levelAssembler.LevelConfig;
        
        for (int i = 0; i < levelConfig.BordersCount; i++)
        {
            var border = GetLevelItem(levelAssembler.BordersPool);

            var xAxisDirection = Mathf.Cos(directionAngle / levelConfig.BordersCount * i);
            var zAxisDirection = Mathf.Sin(directionAngle / levelConfig.BordersCount * i);
            
            var position = new Vector3();
            
            position.y = 0;
            position.x = (levelAssembler.GroundLength / 2 + levelConfig.ObstaclePrefab.transform.localScale.x) * xAxisDirection;
            position.z = (levelAssembler.GroundWidth / 2 + levelConfig.ObstaclePrefab.transform.localScale.z) * zAxisDirection;

            var scale = new Vector3();
            
            scale.y = levelConfig.BorderPrefab.transform.localScale.y;
            scale.x = (levelAssembler.GroundLength + levelConfig.PassWidth) * Mathf.Abs(zAxisDirection) +
                levelConfig.BorderPrefab.transform.localScale.z;
            scale.z = (levelAssembler.GroundWidth + levelConfig.PassWidth) * Mathf.Abs(xAxisDirection) + 
                      levelConfig.BorderPrefab.transform.localScale.x;
            
            border.transform.position = position;
            border.transform.localScale = scale;
            border.transform.SetParent(levelAssembler.Ground.transform);
        }
    }
}
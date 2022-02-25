using UnityEngine;

public class BordersBuilder : Builder
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetLevelBorders(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }

    private void SetLevelBorders(LevelAssembler levelAssembler)
    {
        float obstaclePrefabXScale = levelAssembler.LevelConfig.ObstaclePrefab.transform.localScale.x;
        float obstaclePrefabZScale = levelAssembler.LevelConfig.ObstaclePrefab.transform.localScale.z;
        
        levelAssembler.Level.LeftBorder = 
            SetBorder(levelAssembler, -levelAssembler.GroundLength / 2 - levelAssembler.LevelConfig.PassWidth + obstaclePrefabXScale, 
                0, obstaclePrefabXScale, levelAssembler.GroundWidth + levelAssembler.LevelConfig.PassWidth);
        
        levelAssembler.Level.RightBorder = 
            SetBorder(levelAssembler, levelAssembler.GroundLength / 2 + obstaclePrefabXScale, 0, obstaclePrefabXScale, 
            levelAssembler.GroundWidth + levelAssembler.LevelConfig.PassWidth);
        
        levelAssembler.Level.BottomBorder = 
            SetBorder(levelAssembler, 0, -levelAssembler.GroundWidth / 2 - levelAssembler.LevelConfig.PassWidth + obstaclePrefabZScale,
            levelAssembler.GroundLength + levelAssembler.LevelConfig.PassWidth, obstaclePrefabZScale);
        
        levelAssembler.Level.TopBorder = SetBorder(levelAssembler, 0, levelAssembler.GroundWidth / 2 + obstaclePrefabZScale, 
            levelAssembler.GroundLength + levelAssembler.LevelConfig.PassWidth, obstaclePrefabZScale);
    }
    
    private Border SetBorder(LevelAssembler levelAssembler, float xPosition, float zPosition, float xScale, float zScale)
    {
        Border border = GetLevelItem(levelAssembler.BordersPool);

        border.transform.position = new Vector3(xPosition, 0, zPosition);
        border.transform.localScale = new Vector3(xScale, levelAssembler.LevelConfig.BorderPrefab.transform.localScale.y, zScale);
        border.transform.SetParent(levelAssembler.Ground.transform);

        return border;
    }
}
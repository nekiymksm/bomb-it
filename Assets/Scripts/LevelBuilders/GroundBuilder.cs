using UnityEngine;

public class GroundBuilder : Builder
{
    public override void Build(LevelAssembler levelAssembler)
    {
        SetGround(levelAssembler);
        
        if (Successor != null)
            Successor.Build(levelAssembler);
    }

    private void SetGround(LevelAssembler levelAssembler)
    {
        var scale = new Vector3();
        
        levelAssembler.GroundLength = levelAssembler.HorizontalLevelSize * levelAssembler.LevelConfig.PassWidth;
        levelAssembler.GroundWidth = levelAssembler.VerticalLevelSize * levelAssembler.LevelConfig.PassWidth;
        
        levelAssembler.Ground.gameObject.SetActive(true);

        scale.x = levelAssembler.GroundLength + levelAssembler.LevelConfig.PassWidth;
        scale.y = levelAssembler.LevelConfig.GroundPrefab.transform.localScale.y;
        scale.z = levelAssembler.GroundWidth + levelAssembler.LevelConfig.PassWidth;
        
        levelAssembler.Ground.transform.localScale = scale;
        levelAssembler.Ground.transform.SetParent(levelAssembler.Level.transform);
    }
}
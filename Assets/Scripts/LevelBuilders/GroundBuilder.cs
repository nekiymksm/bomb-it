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
        levelAssembler.GroundLength = levelAssembler.HorizontalLevelSize * levelAssembler.LevelConfig.PassWidth;
        levelAssembler. GroundWidth = levelAssembler.VerticalLevelSize * levelAssembler.LevelConfig.PassWidth;
        
        levelAssembler.Ground.gameObject.SetActive(true);
        levelAssembler.Ground.transform.localScale = 
            new Vector3(levelAssembler.GroundLength + levelAssembler.LevelConfig.GroundPrefab.transform.localScale.x, 
            levelAssembler.LevelConfig.GroundPrefab.transform.localScale.y, 
            levelAssembler.GroundWidth + levelAssembler.LevelConfig.GroundPrefab.transform.localScale.z);
        levelAssembler.Ground.transform.SetParent(levelAssembler.Level.transform);
    }
}
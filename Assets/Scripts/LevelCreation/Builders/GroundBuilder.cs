using UnityEngine;

public class GroundBuilder : Builder
{
    public override void Build(LevelItemsDirector levelItemsDirector)
    {
        SetGround(levelItemsDirector);
        
        if (Successor != null)
            Successor.Build(levelItemsDirector);
    }

    private void SetGround(LevelItemsDirector levelItemsDirector)
    {
        var scale = new Vector3();
        
        levelItemsDirector.LevelLength = levelItemsDirector.HorizontalSize * levelItemsDirector.LevelConfig.PassWidth;
        levelItemsDirector.LevelWidth = levelItemsDirector.VerticalSize * levelItemsDirector.LevelConfig.PassWidth;
        
        levelItemsDirector.Ground.gameObject.SetActive(true);

        scale.x = levelItemsDirector.LevelLength + levelItemsDirector.LevelConfig.PassWidth;
        scale.y = levelItemsDirector.LevelConfig.GroundPrefab.transform.localScale.y;
        scale.z = levelItemsDirector.LevelWidth + levelItemsDirector.LevelConfig.PassWidth;
        
        levelItemsDirector.Ground.transform.localScale = scale;
    }
}
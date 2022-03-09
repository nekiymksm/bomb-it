using UnityEngine;

public class GroundBuilder : Builder
{
    public override void Build(LevelDirector levelDirector)
    {
        SetGround(levelDirector);
        
        if (Successor != null)
            Successor.Build(levelDirector);
    }

    private void SetGround(LevelDirector levelDirector)
    {
        var scale = new Vector3();
        
        levelDirector.LevelLength = levelDirector.HorizontalSize * levelDirector.LevelConfig.PassWidth;
        levelDirector.LevelWidth = levelDirector.VerticalSize * levelDirector.LevelConfig.PassWidth;
        
        levelDirector.Ground.gameObject.SetActive(true);

        scale.x = levelDirector.LevelLength + levelDirector.LevelConfig.PassWidth;
        scale.y = levelDirector.LevelConfig.GroundPrefab.transform.localScale.y;
        scale.z = levelDirector.LevelWidth + levelDirector.LevelConfig.PassWidth;
        
        levelDirector.Ground.transform.localScale = scale;
        levelDirector.Ground.transform.SetParent(levelDirector.Level.transform);
    }
}
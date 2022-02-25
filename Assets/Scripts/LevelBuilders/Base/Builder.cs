using System.Collections.Generic;

public abstract class Builder
{
    public Builder Successor { get; set; }
    
    public abstract void Build(LevelAssembler levelAssembler);
    
    protected T GetLevelItem<T>(List<T> levelItemsPool) where T : LevelItem
    {
        foreach (var levelItem in levelItemsPool)
        {
            if (levelItem.gameObject.activeSelf == false)
            {
                levelItem.gameObject.SetActive(true);
                
                return levelItem;
            }
        }

        return null;
    }
}
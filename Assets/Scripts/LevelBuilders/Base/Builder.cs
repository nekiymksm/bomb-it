public abstract class Builder
{
    public Builder Successor { get; set; }
    
    public abstract void Build(LevelDirector levelDirector);
}
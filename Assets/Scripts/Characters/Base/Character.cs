using LevelCreation;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private Level _level;
    
    public Level Level => _level;

    private void Awake()
    {
        _level = GetComponentInParent<Level>();
        
        Init();
    }

    protected virtual void Init()
    {
        
    }
}
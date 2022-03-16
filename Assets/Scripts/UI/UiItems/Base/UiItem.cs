using UnityEngine;

public abstract class UiItem : MonoBehaviour
{
    protected UiRoot UiRoot;
    protected GameDirector GameDirector;

    private void Awake()
    {
        UiRoot = GetComponentInParent<UiRoot>();
        GameDirector = UiRoot.GameDirector;
        
        Init();
    }

    private void OnEnable()
    {
        OnOpen();
    }

    private void OnDisable()
    {
        OnClose();
    }

    protected virtual void Init()
    {
        
    }

    protected virtual void OnOpen()
    {
        
    }
    
    protected virtual void OnClose()
    {
        
    }
}
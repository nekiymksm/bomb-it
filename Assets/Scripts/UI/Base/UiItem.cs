using UnityEngine;

public abstract class UiItem : MonoBehaviour
{
    private void OnEnable()
    {
        OnOpen();
    }

    private void OnDisable()
    {
        OnClose();
    }

    protected virtual void OnOpen()
    {
        
    }
    
    protected virtual void OnClose()
    {
        
    }
}
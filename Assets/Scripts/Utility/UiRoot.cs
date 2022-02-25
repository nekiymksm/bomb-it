using UnityEngine;

public class UiRoot : MonoBehaviour
{
    [SerializeField] private UiItem[] _uiItems;

    public T GetUiItem<T>() where T : UiItem
    {
        foreach (var uiItem in _uiItems)
        {
            if (uiItem.GetType() == typeof(T))
            {
                return uiItem as T;
            }
        }

        return null;
    }
}
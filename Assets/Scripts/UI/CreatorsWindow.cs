using UnityEngine;
using UnityEngine.UI;

public class CreatorsWindow : UiItem
{
    [SerializeField] private Button _closeButton;

    protected override void OnOpen()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    protected override void OnClose()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }
    
    public void OnUrlClick(string url)
    {
        Application.OpenURL(url);
    }
    
    private void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
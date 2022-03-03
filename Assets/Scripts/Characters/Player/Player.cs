using UnityEngine;

public class Player : Character
{
    [SerializeField] private BombingConfig _bombingConfig;
    
    private ItemsPool _bombsPool;
    
    public ItemsPool BombsPool => _bombsPool;

    protected override void Init()
    {
        LoadBombsPool();
    }

    private void OnEnable()
    {
        _bombsPool.RefreshItemsPool();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out BlastWave blastWave))
        {
            gameObject.SetActive(false);
        }
    }

    private void LoadBombsPool()
    {
        _bombsPool = new ItemsPool();
        
        _bombsPool.LoadItemsPool(_bombingConfig.BombPrefab.gameObject, transform, _bombingConfig.BombsCount);
    }
}
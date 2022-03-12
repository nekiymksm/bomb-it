using System.Collections;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    [SerializeField] private BombingConfig _bombingConfig;

    private Bomb _bomb;
    private Vector3 _direction;
    private float _distance;
    
    private Vector3 _defaultScale;
    private Transform _defaultTransform;
    private Quaternion _defaultRotation;

    private void Awake()
    {
        _defaultScale = transform.localScale;
        _defaultRotation = transform.rotation;
        _defaultTransform = transform.parent;
    }

    private void OnEnable()
    {
        StartCoroutine(DelayDisable());
    }

    public void SetWave(Bomb bomb, Vector3 direction)
    {
        _bomb = bomb;
        _direction = direction;
        _distance = GetWaveDistance();
        
        SetPosition();
        SetScale();
    }
    
    private float GetWaveDistance()
    {
        var spawnDistance = _bombingConfig.ExplosionWaveDistance / 2;
        
        bool isHit = Physics.Raycast(_bomb.transform.position, _direction, out RaycastHit hit, _bombingConfig.ExplosionWaveDistance);

        if (isHit && hit.collider.TryGetComponent(out LevelItem levelItem))
        {
            spawnDistance = hit.distance / 2;
        }

        return spawnDistance;
    }

    private void SetPosition()
    {
        var position = new Vector3();
        
        position.x = _bomb.transform.position.x + _distance * _direction.x;
        position.y = _bomb.transform.position.y;
        position.z = _bomb.transform.position.z + _distance * _direction.z;

        transform.position = position;
    }

    private void SetScale()
    {
        var scale = new Vector3();
        
        scale.x = _distance * 2 * Mathf.Abs(_direction.x) + transform.localScale.x;
        scale.y = transform.localScale.y;
        scale.z = _distance * 2 * Mathf.Abs(_direction.z) + transform.localScale.z;

        transform.localScale = scale;
    }

    private void SetDefaultValues()
    {
        transform.localScale = _defaultScale;
        transform.rotation = _defaultRotation;
        gameObject.transform.SetParent(_defaultTransform);
    }

    private IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(_bombingConfig.ExplosionDuration);
        
        SetDefaultValues();
        gameObject.SetActive(false);
    }
}
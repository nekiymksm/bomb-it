using System.Collections;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    [SerializeField] private BombingConfig _bombingConfig;

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
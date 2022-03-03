using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private BombingConfig _bombingConfig;

    private ItemsPool _blastWaves;
    private Level _level;

    private void Awake()
    {
        _level = GetComponentInParent<Player>().Level;
        
        LoadBlastWaves();
    }

    private void OnEnable()
    {
        StartCoroutine(DelayExplosion());
    }

    private void LoadBlastWaves()
    {
        _blastWaves = new ItemsPool();
        
        _blastWaves.LoadItemsPool(_bombingConfig.BlastWavePrefab.gameObject, transform, _bombingConfig.BlastWavesCount);
    }

    private void Explode()
    {
        var explodeDirectionAngle = 360 * Mathf.Deg2Rad;
        
        for (int i = 0; i < _bombingConfig.BlastWavesCount; i++)
        {
            var blastWave = _blastWaves.TryGetItem();
            var direction = GetExplodeDirection(explodeDirectionAngle, i);
            var distance = GetExplodeDistance(direction);
            var position = new Vector3();

            position.x = transform.position.x + distance * direction.x;
            position.y = transform.position.y;;
            position.z = transform.position.z + distance * direction.z;

            blastWave.transform.SetParent(_level.transform);
            blastWave.transform.position = position;
            
            SetExplodeScale(blastWave, distance, i);
        }

        gameObject.SetActive(false);
    }

    private Vector3 GetExplodeDirection(float explodeDirectionAngle, int directionNumber)
    {
        var explodeDirection = new Vector3();
        
        explodeDirection.x = Mathf.Cos(explodeDirectionAngle / _bombingConfig.BlastWavesCount * directionNumber);
        explodeDirection.y = transform.position.y;
        explodeDirection.z = Mathf.Sin(explodeDirectionAngle / _bombingConfig.BlastWavesCount * directionNumber);

        return explodeDirection;
    }

    private float GetExplodeDistance(Vector3 explodeDirection)
    {
        var spawnDistance = _bombingConfig.ExplosionWaveDistance / 2;

        if (Physics.Raycast(transform.position, explodeDirection, out RaycastHit hit, _bombingConfig.ExplosionWaveDistance)
            && hit.collider.TryGetComponent(out Obstacle obstacle)) {spawnDistance = hit.distance / 2;}

        return spawnDistance;
    }

    private void SetExplodeScale(GameObject blastWave, float distance, float blastNumber)
    {
        blastWave.transform.Rotate(0, 360 / _bombingConfig.BlastWavesCount * blastNumber , 0);
        
        blastWave.transform.localScale = new Vector3(distance * 2, 
            blastWave.transform.localScale.y, blastWave.transform.localScale.z);
    }

    private IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(_bombingConfig.DelayToExplosion);

        Explode();
    }
}
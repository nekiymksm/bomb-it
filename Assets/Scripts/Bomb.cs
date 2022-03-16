using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private BombingConfig _bombingConfig;
    [SerializeField] private BlastWave[] _blastWaves;
    
    private Player _player;
    
    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    private void OnEnable()
    {
        StartCoroutine(DelayExplosion());
    }

    private void Explode()
    {
        var explodeDirectionAngle = 360 * Mathf.Deg2Rad;
        
        for (int i = 0; i < _blastWaves.Length; i++)
        {
            _blastWaves[i].gameObject.SetActive(true);
            _blastWaves[i].SetWave(this, GetExplodeDirection(explodeDirectionAngle, i));
            _blastWaves[i].transform.SetParent(_player.Level.transform);
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

    private IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(_bombingConfig.DelayToExplosion);

        Explode();
    }
}
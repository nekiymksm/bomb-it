using UnityEngine;

[CreateAssetMenu(fileName = "BombingConfig", menuName = "Configs/BombingConfig")]
public class BombingConfig : ScriptableObject
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private int _bombsCount;
    [SerializeField] private int _blastWavesCount;
    [SerializeField] private float _delayToExplosion;
    [SerializeField] private float _explosionWaveDistance;
    [SerializeField] private float _explosionDuration;

    public Bomb BombPrefab => _bombPrefab;
    public int BombsCount => _bombsCount;
    public int BlastWavesCount => _blastWavesCount;
    public float DelayToExplosion => _delayToExplosion;
    public float ExplosionWaveDistance => _explosionWaveDistance;
    public float ExplosionDuration => _explosionDuration;
}
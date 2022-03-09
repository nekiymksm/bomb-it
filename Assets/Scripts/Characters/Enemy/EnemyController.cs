using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _maxMovingDuration;
    [SerializeField] private float _minMovingDuration;
    
    private Level _level;

    private void Awake()
    {
        _level = _enemy.Level;
    }
    
    private void OnEnable()
    {
        _level.LevelStarted += StartMove;
    }

    private void OnDisable()
    {
        _level.LevelStarted -= StartMove;
        
        _navMeshAgent.enabled = false;
    }

    private void StartMove()
    {
        if (gameObject.activeSelf)
        {
            _navMeshAgent.enabled = true;
            
            Move();
        }
    }

    private void Move()
    {
        var horizontalLevelLimit = _level.LevelDirector.Ground.transform.localScale.x / 2;
        var verticalLevelLimit = _level.LevelDirector.Ground.transform.localScale.z / 2;

        _navMeshAgent.SetDestination(new Vector3(Random.Range(-horizontalLevelLimit, horizontalLevelLimit), 
            transform.position.y, Random.Range(-verticalLevelLimit, verticalLevelLimit)));
        
        StartCoroutine(DelayDestinationChange());
    }

    private IEnumerator DelayDestinationChange()
    {
        yield return new WaitForSeconds(Random.Range(_minMovingDuration, _maxMovingDuration));
        
        Move();
    }
}
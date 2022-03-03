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
        var destination = new Vector3();
        
        destination.x = Random.Range(_level.LeftBorder.transform.position.x, _level.RightBorder.transform.position.x);
        destination.y = transform.position.y;
        destination.z = Random.Range(_level.BottomBorder.transform.position.z, _level.TopBorder.transform.position.z);
        
        _navMeshAgent.SetDestination(destination);
        
        StartCoroutine(DelayDestinationChange());
    }

    private IEnumerator DelayDestinationChange()
    {
        yield return new WaitForSeconds(Random.Range(_minMovingDuration, _maxMovingDuration));
        
        Move();
    }
}
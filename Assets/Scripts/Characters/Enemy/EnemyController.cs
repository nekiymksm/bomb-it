using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _maxMovingDuration;
    [SerializeField] private float _minMovingDuration;

    private Level _level;
    private float _horizontalPointer;
    private float _verticalPointer;

    private void Awake()
    {
        _level = GetComponentInParent<Level>();
    }

    private void OnEnable()
    {
        _level.LevelStarted += Move;
    }

    private void OnDisable()
    {
        _navMeshAgent.enabled = false;
        
        _level.LevelStarted -= Move;
    }

    private void Move()
    {
        if (gameObject.activeSelf)
        {
            _navMeshAgent.enabled = true;
            StartMoving();
        }
    }

    private void StartMoving()
    {
        _horizontalPointer = Random.Range(_level.LeftBorder.transform.position.x, _level.RightBorder.transform.position.x);
        _verticalPointer = Random.Range(_level.BottomBorder.transform.position.z, _level.TopBorder.transform.position.z);

        _navMeshAgent.destination = new Vector3(_horizontalPointer, transform.position.y, _verticalPointer);
        
        StartCoroutine(DelayDestinationChange());
    }

    private IEnumerator DelayDestinationChange()
    {
        yield return new WaitForSeconds(Random.Range(_minMovingDuration, _maxMovingDuration));
        
        StartMoving();
    }
}
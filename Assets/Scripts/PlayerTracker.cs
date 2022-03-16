using LevelCreation;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private float _moveSpeed;

    private Camera _camera;
    private Player _player;
    
    private float _leftLimit;
    private float _rightLimit;
    private float _bottomLimit;
    private float _topLimit;

    private void Awake()
    {
        _camera = Camera.main;
        _player = _level.CharactersDirector.Player;
    }

    private void Start()
    {
        _level.LevelStarted += SetCamera;
    }
    
    private void FixedUpdate()
    {
        if (new Vector3(_player.transform.position.x, 0, _player.transform.position.z) != Vector3.zero)
            SetPosition();
    }

    private void SetPosition()
    {
        var positionInTrackedArea = new Vector3();
        
        positionInTrackedArea.x = Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit);
        positionInTrackedArea.y = _defaultPosition.y;
        positionInTrackedArea.z = Mathf.Clamp(transform.position.z, _bottomLimit, _topLimit);

        transform.position = Vector3.MoveTowards(positionInTrackedArea,
            _player.transform.position + _defaultPosition, _moveSpeed * Time.deltaTime);
    }
    
    private void SetCamera()
    {
        var groundScale = _level.LevelItemsDirector.Ground.transform.localScale;
        
        _leftLimit = -groundScale.x / 2 + _camera.orthographicSize * _camera.aspect;
        _rightLimit = groundScale.x / 2 - _camera.orthographicSize * _camera.aspect;
        _bottomLimit = -groundScale.z / 2 - _camera.orthographicSize;
        _topLimit = groundScale.z / 2 - _camera.orthographicSize - _defaultPosition.y;

        transform.position = _player.transform.position + _defaultPosition;
        SetPosition();
    }
}
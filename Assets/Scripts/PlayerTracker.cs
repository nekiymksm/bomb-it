using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _indent;

    private Camera _camera;
    private PlayerController _playerController;
    
    private float _leftCameraLimit;
    private float _rightCameraLimit;
    private float _bottomCameraLimit;
    private float _topCameraLimit;
    
    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Start()
    {
        _level.LevelStarted += SetLimits;
        
        _playerController = _level.CharactersPool[0].GetComponent<PlayerController>();
        _defaultPosition += _level.CharactersPool[0].transform.position;
        transform.position = _defaultPosition;
    }
    
    private void FixedUpdate()
    {
        SetCamera();
    }
    
    private void SetCamera()
    {
        var limitsPointer = new Vector3(Mathf.Clamp(transform.position.x, _leftCameraLimit, _rightCameraLimit), 
            _defaultPosition.y, Mathf.Clamp(transform.position.z, _bottomCameraLimit, _topCameraLimit));
        
        var lookVector = new Vector3(_playerController.HorizontalPointer * _indent, 0, 
            _playerController.VerticalPointer * _indent);
    
        if (lookVector != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(limitsPointer,
                _playerController.transform.position + _defaultPosition + lookVector, _moveSpeed * Time.deltaTime);
        }
    }
    
    private void SetLimits()
    {
        _leftCameraLimit = -_level.LeftBorder.transform.position.x + _camera.orthographicSize * _camera.aspect;
        _rightCameraLimit = _level.RightBorder.transform.position.x - _camera.orthographicSize * _camera.aspect;
        _bottomCameraLimit = -_level.BottomBorder.transform.position.z;
        _topCameraLimit = _level.TopBorder.transform.position.z + _defaultPosition.z * 2;
    }
}
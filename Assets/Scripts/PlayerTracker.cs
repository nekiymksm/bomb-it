using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private float _moveSpeed;

    private Camera _camera;
    private PlayerController _playerController;
    
    private float _leftLimit;
    private float _rightLimit;
    private float _bottomLimit;
    private float _topLimit;
    
    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Start()
    {
        _level.LevelStarted += SetCamera;

        _playerController = _level.Player.GetComponent<PlayerController>();
    }
    
    private void Update()
    {
        if (new Vector3(_playerController.HorizontalPointer, 0, _playerController.VerticalPointer) != Vector3.zero)
            SetPosition();
    }

    private void SetPosition()
    {
        var xAxisTrackArea = Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit);
        var zAxisTrackArea = Mathf.Clamp(transform.position.z, _bottomLimit, _topLimit);
        
        transform.position = Vector3.MoveTowards(new Vector3(xAxisTrackArea, _defaultPosition.y, zAxisTrackArea),
            _playerController.transform.position + _defaultPosition, _moveSpeed * Time.deltaTime);
    }
    
    private void SetCamera()
    {
        _leftLimit = _level.LeftBorder.transform.position.x + _camera.orthographicSize * _camera.aspect;
        _rightLimit = _level.RightBorder.transform.position.x - _camera.orthographicSize * _camera.aspect;
        _bottomLimit = _level.BottomBorder.transform.position.z - _camera.orthographicSize;
        _topLimit = _level.TopBorder.transform.position.z - _camera.orthographicSize - _defaultPosition.y;

        transform.position = _playerController.transform.position + _defaultPosition;
        SetPosition();
    }
}
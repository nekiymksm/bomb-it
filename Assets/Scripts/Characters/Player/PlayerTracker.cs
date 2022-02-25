using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    // [SerializeField] private PlayerController _playerController;
    // [SerializeField] private Vector3 _defaultPosition;
    // [SerializeField] private float _moveSpeed;
    // [SerializeField] private float _indent;
    //
    // [SerializeField] private Barrier _leftLevelLimit;
    // [SerializeField] private Barrier _rightLevelLimit;
    // [SerializeField] private Barrier _bottomLevelLimit;
    // [SerializeField] private Barrier _topLevelLimit;
    //
    // private Camera _camera;
    //
    // private float _leftCameraLimit;
    // private float _rightCameraLimit;
    // private float _bottomCameraLimit;
    // private float _topCameraLimit;
    //
    // private void Awake()
    // {
    //     _camera = Camera.main;
    //     SetLimits();
    // }
    //
    // private void Start()
    // {
    //     transform.position = _defaultPosition;
    // }
    //
    // private void FixedUpdate()
    // {
    //     SetCamera();
    // }
    //
    // private void SetCamera()
    // {
    //     var limitsPointer = new Vector3(Mathf.Clamp(transform.position.x, _leftCameraLimit, _rightCameraLimit), 
    //         _defaultPosition.y, Mathf.Clamp(transform.position.z, _bottomCameraLimit, _topCameraLimit));
    //     
    //     var lookVector = new Vector3(_playerController.HorizontalPointer * _indent, 0, 
    //         _playerController.VerticalPointer * _indent);
    //
    //     if (lookVector != Vector3.zero)
    //     {
    //         transform.position = Vector3.MoveTowards(limitsPointer,
    //             _playerController.transform.position + _defaultPosition + lookVector, _moveSpeed * Time.deltaTime);
    //     }
    // }
    //
    // private void SetLimits()
    // {
    //     _leftCameraLimit = -_rightLevelLimit.transform.position.x + _camera.orthographicSize * _camera.aspect;
    //     _rightCameraLimit = _rightLevelLimit.transform.position.x - _camera.orthographicSize * _camera.aspect;
    //     _bottomCameraLimit = -_topLevelLimit.transform.position.z;
    //     _topCameraLimit = _topLevelLimit.transform.position.z + _defaultPosition.z * 2;
    // }
}
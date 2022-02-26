using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _moveSpeedModifier;
    [SerializeField] private float _rotateSpeedModifier;

    private float _horizontalPointer;
    private float _verticalPointer;
    
    public float HorizontalPointer => _horizontalPointer;
    public float VerticalPointer => _verticalPointer;
    
    private void Update()
    {
        _horizontalPointer = Input.GetAxisRaw("Horizontal");
        _verticalPointer = Input.GetAxisRaw("Vertical");
        
        Move();
    }
    
    private void Move()
    {
        var moveVector = new Vector3(_horizontalPointer, 0, _verticalPointer) * _moveSpeedModifier;
        
        _characterController.Move(moveVector * Time.deltaTime);
    
        if (moveVector != Vector3.zero)
        {
            Quaternion moveDirection = Quaternion.LookRotation(new Vector3(_horizontalPointer, 0, _verticalPointer));
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, moveDirection, 
                _rotateSpeedModifier * Time.deltaTime);
        }
    }
}
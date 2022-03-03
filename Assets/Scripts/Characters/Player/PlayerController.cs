using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _moveSpeedModifier;
    [SerializeField] private float _rotateSpeedModifier;

    private Level _level;

    private void Awake()
    {
        _level = _player.Level;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        TrySpawnBomb();
    }

    private void Move()
    {
        var horizontalPointer = Input.GetAxisRaw("Horizontal");
        var verticalPointer = Input.GetAxisRaw("Vertical");
        
        var moveVector = new Vector3(horizontalPointer, 0, verticalPointer) * _moveSpeedModifier;
        
        _characterController.Move(moveVector * Time.deltaTime);
    
        if (moveVector != Vector3.zero)
        {
            var rotateDirection = Quaternion.LookRotation(new Vector3(horizontalPointer, 0, verticalPointer));
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateDirection, 
                _rotateSpeedModifier * Time.deltaTime);
        }
    }

    private void TrySpawnBomb()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bomb = _player.BombsPool.TryGetItem();

            if (bomb != null)
            {
                bomb.transform.SetParent(_level.transform);
                bomb.transform.position = _player.transform.position;
                bomb.transform.rotation = _level.transform.rotation;
            }
        }
    }
}
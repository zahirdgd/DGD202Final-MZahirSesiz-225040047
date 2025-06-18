using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [Header("Movement Parameters")]
    [field: SerializeField] public float MoveSpeed { get; set; } = 5f;
    [SerializeField] private float _turnSpeed = 100f;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        
        if (_rigidbody == null)
        {
            Debug.LogError("PlayerMover requires a Rigidbody component!");
        }
        else
        {
            Debug.Log($"PlayerMover initialized. MoveSpeed: {MoveSpeed}, TurnSpeed: {_turnSpeed}");
        }
    }

    public void Move(Vector2 direction)
    {
        float moveX = direction.x;
        float moveZ = direction.y;

        
        if (Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f)
        {
            Debug.Log($"PlayerMover.Move called with direction: {direction}");
        }

        transform.Rotate(Vector3.up, moveX * _turnSpeed * Time.deltaTime, Space.World);
        
        _rigidbody.linearVelocity = transform.forward * (moveZ * MoveSpeed);
    }
}
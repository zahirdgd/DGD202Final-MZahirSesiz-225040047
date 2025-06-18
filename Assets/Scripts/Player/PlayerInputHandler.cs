using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput inputActions;
    private PlayerMover playerMover;

    private void Awake()
    {
        
        inputActions = new PlayerInput();
        
        
        playerMover = GetComponent<PlayerMover>();
        
        
        if (playerMover.MoveSpeed == 0)
        {
            playerMover.MoveSpeed = 5f;
            Debug.Log("Set default MoveSpeed to 5");
        }
    }

    private void OnEnable()
    {
        
        inputActions.Player.Enable();
        Debug.Log("Player input enabled");
    }

    private void OnDisable()
    {
        
        inputActions.Player.Disable();
        Debug.Log("Player input disabled");
    }

    private void Update()
    {
        
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        
        
        if (moveInput.magnitude > 0.1f)
        {
            Debug.Log($"Input received: {moveInput}");
        }
        
        
        playerMover.Move(moveInput);
    }
} 
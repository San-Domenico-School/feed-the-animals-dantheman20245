/******************************************************************************  
 * Class: PlayerMovementController  
 * Purpose: Controls player movement based on input.  
 * Component Of: Player GameObject  
 * Fields: 
 *   - playerSpeed (float) → Controls movement speed.  
 *   - widthOfField (float) → Prevents movement beyond boundaries.  
 *   - moveDirection (float) → Stores input direction.    
 * Behaviors:
 *   - Start() → Initializes variables.  
 *   - Update() → Executes the PlayerMovement methods per frame.
 *   - OnMovementInput() → Handles player input events.
 *   - DeterminePlayerDirection() → Assigns player's move direction -1, 1, or 0 
 *                                  to determine the direction of motion: left, 
 *                                  right, or stationary.
 *   - PlayerMovement() → Processes movement logic.
 * Access: To enforce encapsulation only OnMovementInput() is visible
 * Author: Daniel Grigoryan
 * Version: Sep 9, 2025 v. 1.0
 *******************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float boostedSpeed = 45f;   // ⭐ NEW — Speed when Z is held
    private float currentSpeed;        // ⭐ NEW — The speed used at any moment


    private float moveDirection;
    public float centerToEdge;

    private void Start()
    {
        centerToEdge = 23.1f;
        currentSpeed = playerSpeed;    // ⭐ NEW
    }

    private void Update()
    {
        HandleSpeedBoost();            // ⭐ NEW
        PlayerMovement();
    }

    // ⭐ NEW — Handles Z-key speed boost
    private void HandleSpeedBoost()
    {
        if (Keyboard.current.zKey.isPressed)
        {
            currentSpeed = boostedSpeed;
        }
        else
        {
            currentSpeed = playerSpeed;
        }
    }

    // Handles player input from the Unity Input System
    public void OnMovementInput(InputAction.CallbackContext ctx)
    {
        DeterminePlayerDirection(ctx.ReadValue<Vector2>());
    }

    private void DeterminePlayerDirection(Vector2 value)
    {
        moveDirection = value.x;
    }

    private void PlayerMovement()
    {
        if ((transform.position.x < centerToEdge && moveDirection > 0) ||
            (transform.position.x > -centerToEdge && moveDirection < 0))
        {
            transform.Translate(Vector3.right * currentSpeed * moveDirection * Time.deltaTime);
        }
    }
}

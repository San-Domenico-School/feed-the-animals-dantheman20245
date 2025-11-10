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
    private int widthofField;
    private float moveDirection;
    public float centerToEdge;


    //Initializes variables
    private void Start()
    {
        centerToEdge = 23.1f;
    }
    //Executed PlayerMovement every frame
    private void Update()
    {
        PlayerMovement();

    }
    //Handles PlayerInput
    public void OnMovementInput(InputAction.CallbackContext ctx)
    {
        DeterminePlayerDirection(ctx.ReadValue<Vector2>());  //Dynamic Method that sends value to DeterMine
    }

    //Assings players move direction
    private void DeterminePlayerDirection(Vector2 value)
    {
        moveDirection = value.x; // Assigns the x-input value to moveDirection
    }

    //proccess movement logic
    private void PlayerMovement()
    {
        if (transform.position.x < centerToEdge && moveDirection > 0 || transform.position.x > -centerToEdge && moveDirection < 0)
        {
            transform.Translate(Vector3.right * playerSpeed * moveDirection * Time.deltaTime);
        }
            
    }
}

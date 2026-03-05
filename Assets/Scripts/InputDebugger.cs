using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDebugger : MonoBehaviour
{
    private void OnEnable() // This method is called when the object becomes enabled and active. It is used to subscribe to the input action events.
    {
        InputManager.Actions.Game.Move.performed += Move_performed;  // Subscribe to the "performed" event of the "Move" action in the "Game" action map. This means that whenever the "Move" action is performed, the Move_performed method will be called.   
        InputManager.Actions.Game.Move.canceled += Move_performed;
    }

    private void Move_performed(InputAction.CallbackContext obj) // This method is called whenever the "Move" action is performed.
    {
        Vector2 input = obj.ReadValue<Vector2>(); // Read the input value as a Vector2
        Debug.Log($"Move {input}"); // Log the input value to the console for debugging purposes
    }

    private void OnDisable() // Unsubscribe from the event when the object is disabled to prevent memory leaks and unintended behavior.
    {
        InputManager.Actions.Game.Move.performed -= Move_performed; // Unsubscribe from the event to avoid potential issues when the object is disabled or destroyed.
        InputManager.Actions.Game.Move.canceled -= Move_performed; // Unsubscribe from the "canceled" event as well.
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour {
    public DefaultInputActions actions;
    
    void OnEnable() {
        actions.Player.Fire.performed += Fire;
        actions.Player.Move.performed += Move;
    }

    private void Move(InputAction.CallbackContext ctx) => Debug.Log(ctx.ReadValue<Vector2>());
    private void Fire(InputAction.CallbackContext ctx) => Debug.Log("Fire");
    private void OnDisable() {
        actions.Player.Fire.performed -= Fire;
        actions.Player.Move.performed -= Move;
    }
}

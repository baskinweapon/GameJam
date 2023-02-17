using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour {
    private  UserInputs actions;

    public static Action OnCastFirstAbility;
    public static Action OnCastSecondAbility;
    public static Action OnCastThirdAbility;
    public static Action OnCastFourAbility;

    public static Action OnRightMouseClick;

    public Vector2 mousePosition;
    
    private void OnEnable() {
        
        actions = new UserInputs();
        actions.Enable();
        
        actions.Player.FirstAbility.performed += CastFirstAbility;
        actions.Player.FirstAbility1.performed += CastSecondAbility;
        actions.Player.FirstAbility2.performed += CastThirdAbility;
        actions.Player.FirstAbility3.performed += CastFourAbility;
        actions.UI.RightClick.performed += RightClick;
    }

    private void Update() {
        mousePosition = actions.UI.Point.ReadValue<Vector2>();
        Debug.Log(mousePosition);
    }

    private void RightClick(InputAction.CallbackContext ctx) {
        Debug.Log("Right CLick");
        OnRightMouseClick?.Invoke();
    }

    public void CastFirstAbility(InputAction.CallbackContext ctx) {
        Debug.Log("First cast");
        OnCastFirstAbility?.Invoke();
    }

    private void CastSecondAbility(InputAction.CallbackContext ctx) {
        Debug.Log("Second cast");
        OnCastSecondAbility?.Invoke();
    }

    private void CastThirdAbility(InputAction.CallbackContext ctx) {
        OnCastThirdAbility?.Invoke();
        Debug.Log("Third cast");
    } 
        
    private void CastFourAbility(InputAction.CallbackContext ctx) => OnCastFourAbility?.Invoke();
    
    private void OnDisable() {
        actions.Player.FirstAbility.performed -= CastFirstAbility;
        actions.Player.FirstAbility1.performed -= CastSecondAbility;
        actions.Player.FirstAbility2.performed -= CastThirdAbility;
        actions.Player.FirstAbility3.performed -= CastFourAbility;
        actions.UI.RightClick.performed -= RightClick;
    }
}

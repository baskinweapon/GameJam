using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem> {
    private  UserInputs actions;

    public static Action OnCastFirstAbility;
    public static Action OnCastSecondAbility;
    public static Action OnCastThirdAbility;
    public static Action OnCastFourAbility;

    public static Action OnRightMouseClick;
    public static Action OnMouseClick;

    public Vector2 mousePosition;
    
    private void OnEnable() {
        
        actions = new UserInputs();
        actions.Enable();
        
        actions.Player.FirstAbility.performed += CastFirstAbility;
        actions.Player.FirstAbility1.performed += CastSecondAbility;
        actions.Player.FirstAbility2.performed += CastThirdAbility;
        actions.Player.FirstAbility3.performed += CastFourAbility;
        actions.Player.MouseRightClick.performed += RightClick;
        actions.UI.Click.performed += Click;
    }
    

    private void Update() {
        mousePosition = actions.UI.Point.ReadValue<Vector2>();
    }

    private void Click(InputAction.CallbackContext ctx) {
        mousePosition = actions.UI.Point.ReadValue<Vector2>();
        OnMouseClick?.Invoke();
    }

    private void RightClick(InputAction.CallbackContext ctx) {
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
        actions.Player.MouseRightClick.performed -= RightClick;
    }
}

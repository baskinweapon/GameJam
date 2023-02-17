using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputSystem : Singleton<InputSystem> {
    private  UserInputs actions;

    public static Action<int> OnCastFirstAbility;
    public static Action<int> OnCastSecondAbility;
    public static Action<int> OnCastThirdAbility;
    public static Action<int> OnCastFourAbility;

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

    public Vector2 GetMousePosition() {
        Debug.Log(mousePosition);
        InputState.Change(Mouse.current.position, mousePosition);
        Debug.Log(mousePosition);
        return  mousePosition;
    }

    private void Click(InputAction.CallbackContext ctx) {
        mousePosition = actions.UI.Point.ReadValue<Vector2>();
        OnMouseClick?.Invoke();
    }

    private void RightClick(InputAction.CallbackContext ctx) {
        OnRightMouseClick?.Invoke();
    }

    public void CastFirstAbility(InputAction.CallbackContext ctx) {
        OnCastFirstAbility?.Invoke(0);
    }

    private void CastSecondAbility(InputAction.CallbackContext ctx) {
        OnCastSecondAbility?.Invoke(1);
    }

    private void CastThirdAbility(InputAction.CallbackContext ctx) {
        OnCastThirdAbility?.Invoke(2);
    } 
        
    private void CastFourAbility(InputAction.CallbackContext ctx) => OnCastFourAbility?.Invoke(3);
    
    private void OnDisable() {
        actions.Player.FirstAbility.performed -= CastFirstAbility;
        actions.Player.FirstAbility1.performed -= CastSecondAbility;
        actions.Player.FirstAbility2.performed -= CastThirdAbility;
        actions.Player.FirstAbility3.performed -= CastFourAbility;
        actions.Player.MouseRightClick.performed -= RightClick;
    }
}

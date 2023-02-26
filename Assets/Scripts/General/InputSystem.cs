using System;
using General;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public enum GameState {
    Pause,
    Play,
    Dialog
}

public class InputSystem : Singleton<InputSystem> {
    private  UserInputs actions;

    public static Action<int> OnCastFirstAbility;
    public static Action<int> OnCastSecondAbility;
    public static Action<int> OnCastThirdAbility;
    public static Action<int> OnCastFourAbility;

    public static Action OnClickEsc;
    public static Action OnRightMouseClick;
    public static Action OnMouseClick;

    public Vector2 mousePosition;
    
    public static Action OnPause;
    public static Action OnPlay;
    public static Action OnDialog;

    private void OnEnable() {
        
        actions = new UserInputs();
        actions.Enable();
        
        actions.Player.FirstAbility.performed += CastFirstAbility;
        actions.Player.FirstAbility1.performed += CastSecondAbility;
        actions.Player.FirstAbility2.performed += CastThirdAbility;
        actions.Player.FirstAbility3.performed += CastFourAbility;
        actions.Player.MouseRightClick.performed += RightClick;
        actions.UI.Click.performed += Click;
        actions.Player.PauseButton.performed += Pause;
    }

    public bool isPaused;
    public void Pause(InputAction.CallbackContext ctx = default) {
        OnClickEsc?.Invoke();
        if (CanvasMain.instance.currentOpenWindow || SceneManager.GetActiveScene().buildIndex == 1) {
            CanvasMain.instance.CloseCurrentWindow();
            return;
        }
        if (!isPaused) {
            isPaused = true;
            ChangeState(GameState.Pause);
            OnPause?.Invoke();
        } else {
            isPaused = false;
            ChangeState(GameState.Play);
            OnPlay?.Invoke();
        }
    }
    
    
    private void Update() {
        mousePosition = Input.mousePosition;
    }

    public Vector2 GetMousePosition() {
        return mousePosition;
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
    
    public void ChangeState(GameState _state) {
        switch (_state) {
            case GameState.Pause:
                Time.timeScale = 0;
                break;
            case GameState.Play:
                Time.timeScale = 1;
                break;
            case GameState.Dialog:
                Time.timeScale = 0;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

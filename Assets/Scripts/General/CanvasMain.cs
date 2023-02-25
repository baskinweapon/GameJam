using System;
using UnityEngine;

namespace General {
    public class CanvasMain : Singleton<CanvasMain> {
        [SerializeField]
        private GameObject swapPanel;

        public void Start() {
            InputSystem.OnClickEsc += ClickEsc;
        }

        public void OpenSwapPanel(Spell spell) {
            InputSystem.instance.ChangeState(GameState.Dialog);
            swapPanel.SetActive(true);
            var panel = swapPanel.GetComponent<SwapPanel>();
            panel.Swap(spell);
        }

        public void ClickEsc() {
            if (swapPanel.activeSelf) {
                CloseSwapPanel();
            }
        }
        
        public void CloseSwapPanel() {
            InputSystem.instance.ChangeState(GameState.Play);
            swapPanel.SetActive(false);
        }

        private void OnDisable() {
            InputSystem.OnClickEsc -= ClickEsc;
        }
    }
}
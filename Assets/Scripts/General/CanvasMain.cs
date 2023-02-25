using System;
using UnityEngine;

namespace General {
    public class CanvasMain : Singleton<CanvasMain> {
        [SerializeField]
        private GameObject swapPanel;

        public GameObject currentOpenWindow;
        
        public void OpenSwapPanel(Spell spell) {
            InputSystem.instance.ChangeState(GameState.Pause);
            currentOpenWindow = swapPanel;
            swapPanel.SetActive(true);
            var panel = swapPanel.GetComponent<SwapPanel>();
            panel.Swap(spell);
        }

        public void CloseCurrentWindow() {
            if (swapPanel.activeSelf) {
                CloseSwapPanel();
            }
        }
        
        public void CloseSwapPanel() {
            InputSystem.instance.ChangeState(GameState.Play);
            currentOpenWindow = null;
            swapPanel.SetActive(false);
        }
    }
}
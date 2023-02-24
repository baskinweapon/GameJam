using System;
using UnityEngine;

namespace General {
    public class CanvasMain : Singleton<CanvasMain> {
        public GameObject swapPanel;
        
        public void OpenSwapPanel(Spell spell) {
            InputSystem.instance.ChangeState(GameState.Dialog);
            swapPanel.SetActive(true);
            var panel = swapPanel.GetComponent<SwapPanel>();
            panel.Swap(spell);
        }

        public void CloseSwapPanel() {
            InputSystem.instance.ChangeState(GameState.Play);
            swapPanel.SetActive(false);
        }
    }
}
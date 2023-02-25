using System;
using System.Collections.Generic;
using UnityEngine;

namespace General {
    public class CanvasMain : Singleton<CanvasMain> {
        [SerializeField]
        private GameObject swapPanel;

        [SerializeField]
        private GameObject deathPanel;

        public GameObject currentOpenWindow;

        private List<GameObject> panels;
        private void Start() {
            panels = new List<GameObject>();
            panels.Add(swapPanel);
            panels.Add(deathPanel);
            
            CloseAllWindow();
        }

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

        public void OpenDeadthPanel() {
            deathPanel.SetActive(true);
        }
        
        public void CloseDeadthPanel() {
            deathPanel.SetActive(false);
        }

        public void CloseAllWindow() {
            foreach (var panel in panels) {
                panel.SetActive(false);
            }
        }
    }
}
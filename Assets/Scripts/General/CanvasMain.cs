using System;
using System.Collections.Generic;
using UnityEngine;

namespace General {
    public class CanvasMain : Singleton<CanvasMain> {
        [SerializeField]
        private GameObject swapPanel;

        [SerializeField]
        private GameObject spellPanel;

        [SerializeField]
        private GameObject deathPanel;

        [SerializeField]
        private GameObject tolkPanel;

        public GameObject currentOpenWindow;

        private List<GameObject> panels;
        private void Start() {
            panels = new List<GameObject>();
            panels.Add(swapPanel);
            panels.Add(deathPanel);
            panels.Add(tolkPanel);

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

        public void OpenTolkPanel(MessageCommunication[] communication) {
            spellPanel.SetActive(false);
            if (tolkPanel.gameObject.activeInHierarchy) return;
            tolkPanel.SetActive(true);
            Tolk.instance.SendSrartMessage(communication);
        }

        public void CloseAllWindow() {
            spellPanel.SetActive(true);
            foreach (var panel in panels) {
                panel.SetActive(false);
            }
            InputSystem.instance.Pause();
        }
    }
}
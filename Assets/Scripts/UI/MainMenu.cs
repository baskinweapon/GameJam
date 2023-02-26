using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject settingsPanel;

    public Slider volumeSlider;

    public void OnEnable() {
        InputSystem.OnClickEsc += Esc;
        Audio.instance.source.volume = PlayerPrefs.GetFloat("volume");
        if (Audio.instance.source.volume == 0) {
            Audio.instance.source.volume = 1;
        }
        volumeSlider.value = Audio.instance.source.volume;
        Audio.instance.StartBackgroundMusic(Audio.instance.mainMenuMusic[0]);
    }

    public void StartGame() {
        Main.instance.StartNewGame();
    }

    public void Settings() {
        settingsPanel.SetActive(true);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Esc() {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float volume) {
        Audio.instance.source.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void OnDisable() {
        InputSystem.OnClickEsc -= Esc;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {
    
    private Image image;
    private void OnEnable() {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        StartCoroutine(AlphaImage());
    }

    IEnumerator AlphaImage() {
        while (image.color.a <= 0.9) {
            image.color = Color.Lerp(image.color, new Color(image.color.r, image.color.g, image.color.b, 1), Time.deltaTime);
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        InputSystem.instance.Pause();
    }

    public void Restart() {
        Main.instance.StartNewGame();
    }

    public void MainMenu() {
        
    }
}

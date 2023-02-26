using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonVisual : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Button button;

    public Color hoverColor;
    public Color defauldColor;

    private TextMeshProUGUI text;
    private void OnEnable() {
        button = GetComponent<Button>();
        text = button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        text.color = hoverColor;
    }


    public void OnPointerExit(PointerEventData eventData) {
        text.color = defauldColor;
    }
}

using General;
using UnityEngine;

public class SpellDrop : MonoBehaviour {
    public SpriteRenderer spellImg;
    public Spell spell;

    private void Start() {
        if (!(Main.instance.settings.s.spells.Length > Main.instance.settings.s.currentSpellId)) return;
        spell = Main.instance.settings.s.spells[Main.instance.settings.s.currentSpellId++];
        spellImg.sprite = spell.icon;
    }

    public void OnTriggerEnter2D(Collider2D col) {
            CanvasMain.instance.OpenSwapPanel(spell);
            Destroy(gameObject);
    }

    
}

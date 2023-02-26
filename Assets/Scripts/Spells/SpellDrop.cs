using General;
using UnityEngine;

public class SpellDrop : MonoBehaviour {
    public SpriteRenderer spellImg;
    public Spell spell;
    
    private void Start() {
        if (!(Main.instance.settings.s.spells.Length > Main.instance.settings.s.currentSpellId)) {
            Destroy(gameObject);
            return;
        }
        spell = Main.instance.settings.s.spells[Main.instance.settings.s.currentSpellId++];
        spellImg.sprite = spell.icon;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player")) {
            CanvasMain.instance.OpenSwapPanel(spell); 
            Destroy(gameObject);
        }
    }

    
}

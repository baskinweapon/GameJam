using System;
using UnityEngine;

public class Damager : MonoBehaviour {
   
   public float damageValue;
   public bool onPlayer;
   
   
   private void OnEnable() {
      Destroy(gameObject, 1f);
   }
   
   private void OnTriggerEnter2D(Collider2D col) {
      if (onPlayer) {
         if (col.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Debug.Log("Damage to player");
            Main.instance.minusHP(damageValue);
         }
      }
      else {
         if (col.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            col.gameObject.GetComponent<EnemyAI>().ChangeHealth(damageValue);
         }
      }
   }
}

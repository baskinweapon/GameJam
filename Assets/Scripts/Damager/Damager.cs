using System;
using UnityEngine;

public class Damager : MonoBehaviour {
   
   public float damageValue;
   public bool onPlayer;
   
   
   private void OnEnable() {
      Destroy(gameObject, 1f);
   }

   private void OnCollisionEnter2D(Collision2D col) {
      if (onPlayer) {
         if (col.gameObject.layer == LayerMask.NameToLayer("Player")) {
            col.gameObject.GetComponent<EnemyAI>().ChangeHealth(damageValue);
         }
      }
      else {
         if (col.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            col.gameObject.GetComponent<EnemyAI>().ChangeHealth(damageValue);
         }
      }
   }
   
   
}

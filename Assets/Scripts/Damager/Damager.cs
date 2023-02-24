using UnityEngine;

public class Damager : MonoBehaviour {
   
   public float damageValue;
   
   private void OnCollisionEnter2D(Collision2D col) {
      if (col.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
         col.gameObject.GetComponent<EnemyAI>().ChangeHealth(damageValue);
      }
   }
}

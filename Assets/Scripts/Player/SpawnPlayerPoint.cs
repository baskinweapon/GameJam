using UnityEngine;

public class SpawnPlayerPoint : MonoBehaviour
{
   private void OnEnable() {
      Main.instance.character.transform.position = transform.position;
   }
}

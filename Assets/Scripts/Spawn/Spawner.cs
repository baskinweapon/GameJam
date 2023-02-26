using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
   public GameObject[] prefabs;


   public void Start() {
      InvokeRepeating(nameof(Create), 1000f, 60f);
   }

   public void Create() {
      var go = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
      go.transform.position = transform.position;
   }
}

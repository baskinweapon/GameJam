using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacter : MonoBehaviour {
	public float speed = 10f;

	private void Update() {
		if (!Mouse.current.rightButton.wasPressedThisFrame) return;
		Debug.Log("Press right Button");
		var target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
		target.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
	
}

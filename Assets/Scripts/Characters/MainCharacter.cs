using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacter : MonoBehaviour {
	public float speed = 10f;


	public void Start() {
		InputSystem.OnMouseClick += MoveTowards;
	}

	private Vector3 target;
	private bool isMoving;
	private void Update() {
		if (isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			if (transform.position == target) {
				isMoving = false;
			}
		}
	}

	private void MoveTowards() {
		Debug.Log(Mouse.current.position.ReadValue());
		target = Camera.main.ScreenToWorldPoint(InputSystem.instance.mousePosition);
		Debug.Log(target);
		target.z = 0;

		isMoving = true;
	}

	private void OnDisable() {
		InputSystem.OnMouseClick -= MoveTowards;
	}
}

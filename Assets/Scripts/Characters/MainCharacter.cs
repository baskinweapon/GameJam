using Pathfinding;
using UnityEngine;

public class MainCharacter : MonoBehaviour {
	public float speed = 10f;
	public Rigidbody2D rb;

	private IAstarAI ai;
	public void Start() {
		InputSystem.OnMouseClick += MoveTowards;
		
		ai = GetComponent<IAstarAI>();
		if (ai != null) ai.onSearchPath += FindPath;
	}


	private void FindPath() {
		Debug.Log("Find Path " +  ai.destination);
		if (target != null && ai != null) ai.destination = target;
	}
	
	private Vector3 target;
	private bool isMoving;
	private void LateUpdate() {
		if (isMoving) {
			
			//rb.AddForce((target - transform.position).normalized * speed);
			//transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			if (transform.position == target) {
				isMoving = false;
			}
		}
	}

	private void MoveTowards() {
		target = Camera.main.ScreenToWorldPoint(InputSystem.instance.mousePosition);
		target.z = 0;

		isMoving = true;
	}

	private void OnDisable() {
		InputSystem.OnMouseClick -= MoveTowards;
	}
}

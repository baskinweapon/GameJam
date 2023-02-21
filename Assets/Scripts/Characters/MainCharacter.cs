using Pathfinding;
using UnityEngine;

public class MainCharacter : MonoBehaviour {
	private IAstarAI ai;
	public void Start() {
		InputSystem.OnMouseClick += MoveTowards;
		
		ai = GetComponent<IAstarAI>();
		if (ai != null) ai.onSearchPath += LateUpdate;
	}


	private void LateUpdate() {
		if (ai != null && target != ai.destination) ai.destination = target;
	}
	
	private Vector3 target;
	private void MoveTowards() {
		target = Camera.main.ScreenToWorldPoint(InputSystem.instance.mousePosition);
		target.z = 0;
	}

	private void OnDisable() {
		InputSystem.OnMouseClick -= MoveTowards;
		if (ai != null) ai.onSearchPath -= LateUpdate;
	}
}

using Pathfinding;
using UnityEngine;

public class MainCharacter : MonoBehaviour {
	private IAstarAI ai;
	public GameObject moveToVisual;
	public Animator animator;

	private GameObject moveTo;
	public void Start() {
		moveTo = Instantiate(moveToVisual);
		moveTo.SetActive(false);
		InputSystem.OnMouseClick += MoveTowards;
		
		ai = GetComponent<IAstarAI>();
		if (ai != null) ai.onSearchPath += LateUpdate;
	}

	private void LateUpdate() {
		if (ai != null && target != ai.destination) ai.destination = target;
		if (Vector2.Distance(transform.position, target) <= 0.5f)
			moveTo.SetActive(false);
	}
	
	private Vector3 target;
	private void MoveTowards() {
		target = Camera.main.ScreenToWorldPoint(InputSystem.instance.mousePosition);
		target.z = 0;
		moveTo.SetActive(true);
		moveTo.transform.position = target;
	}

	private void OnDisable() {
		InputSystem.OnMouseClick -= MoveTowards;
		if (ai != null) ai.onSearchPath -= LateUpdate;
	}
}

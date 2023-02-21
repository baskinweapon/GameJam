using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float minPositionCamX;
    [SerializeField] private float maxPositionCamX;
    [SerializeField] private float minPositionCamY;
    [SerializeField] private float maxPositionCamY;

    private Transform pleerTransform;

    private void Start()
    {
        pleerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
            transform.position = new Vector3(Mathf.Clamp(pleerTransform.position.x, minPositionCamX, maxPositionCamX),
                Mathf.Clamp(pleerTransform.position.y, minPositionCamY, maxPositionCamY),
                transform.position.z);
    }
}


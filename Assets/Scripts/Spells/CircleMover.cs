using UnityEngine;

public class CircleMover : MonoBehaviour {
    private float lifetime;
    private float size;
    private float distanceTraveled;
    private Vector3 startPosition;
    private float startTime;
    
    public void Initialize(float size, float lifetime, float distanceTraveled)
    {
        this.size = size;
        this.lifetime = lifetime;
        this.distanceTraveled = distanceTraveled;
        startPosition = transform.position;
        startTime = Time.time;
    }

    private void Update()
    {
        float deltaTime = Time.time - startTime;
        float t = deltaTime / lifetime;

        float yOffset = Mathf.Sin(t * Mathf.PI) * size;
        float xOffset = Mathf.Cos(t * Mathf.PI * 2f) * size;

        transform.position = startPosition + new Vector3(xOffset, yOffset, 0f);
        transform.localScale = Vector3.one * (1f - t);

        if (deltaTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

}

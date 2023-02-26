using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MovingCircles : EnemySpellBase
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private float radius = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float circleSpacing = 0.1f;
    [SerializeField] private float maxLifetime = 5f;

    private float angle;
    private float timeSinceLastCircle;
    private float distanceTraveled;

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        distanceTraveled += speed * deltaTime;
        angle += rotationSpeed * deltaTime;

        Vector3 position = transform.position + Quaternion.Euler(0f, 0f, angle) * Vector3.right * radius;
        timeSinceLastCircle += deltaTime;
        if (timeSinceLastCircle >= circleSpacing)
        {
            timeSinceLastCircle -= circleSpacing;
            CreateCircle(position);
        }
    }

    private void CreateCircle(Vector3 position)
    {
        float size = Random.Range(0.5f, 1.5f);
        float lifetime = Random.Range(0.5f, maxLifetime);

        GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity);
        CircleMover mover = circle.GetComponent<CircleMover>();
        mover.Initialize(size, lifetime, distanceTraveled);
    }

    public override void StartAttack() {
        
    }
}




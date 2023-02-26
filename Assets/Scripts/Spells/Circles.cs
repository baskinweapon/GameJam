using System.Collections.Generic;
using UnityEngine;

namespace Spells {
    public class Circles : EnemySpellBase {
        
    public GameObject prefab; // префаб, который нужно создавать
    public int count; // количество префабов для создания
    public float delay; // задержка между созданием префабов
    public float speed; // скорость движения префабов
    public float radius; // радиус окружности, по которой будут двигаться префабы
    public float amplitude; // амплитуда колебаний по оси Y
    public float frequency;
    
    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // список созданных префабов
    private float timer = 0f; // таймер для задержки между созданием префабов
    private Vector3 center; // центр окружности, по которой двигаются префабы
    private float angle = 0f; // угол для распределения префабов по окружности

    
    
    void Start() {
        center = transform.position; // устанавливаем центр окружности в позицию спаунера
    }

    void Update() {
        if (!first) return;
        center = transform.position;
        timer += Time.deltaTime; // обновляем таймер

        if (spawnedPrefabs.Count < count && timer >= delay) {
            // создаем новый префаб
            GameObject newPrefab = Instantiate(prefab, center, Quaternion.identity);
            spawnedPrefabs.Add(newPrefab);

            // распределяем префабы по окружности
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            newPrefab.transform.position += direction * radius;

            // увеличиваем угол для следующего префаба
            angle += 360f / count;

            // сбрасываем таймер
            timer = 0f;
        }

        // двигаем префабы по окружности
        for (int i = 0; i < spawnedPrefabs.Count; i++)
        {
            GameObject prefab = spawnedPrefabs[i];
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            float offsetY = amplitude * Mathf.Sin(frequency * Time.time + angle * Mathf.Deg2Rad);
            prefab.transform.position = center + direction * radius + Vector3.up * offsetY;
            angle += 0.1f;
        }
    }

    private bool first;
    public override void StartAttack() {
        first = true;
        spawnedPrefabs.Clear();
    }
    }
}



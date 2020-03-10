using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid _template;
    [SerializeField] private Transform _asteroidTarget;
    [SerializeField] float _spawnDelay;

    private float _spawnRadius;

    private void Start()
    {
        float cameraHeight = Camera.main.orthographicSize;
        _spawnRadius = Mathf.Sqrt(cameraHeight * cameraHeight * 5);

        StartCoroutine(Spawn(_spawnDelay));
    }

    private IEnumerator Spawn(float _delay)
    {
        while (true)
        {
            Vector3 spawnPosition = RandomOnCircle(_spawnRadius);
            Asteroid inst = Instantiate(_template, spawnPosition, Quaternion.identity);
            inst.Init(_asteroidTarget, Random.Range(1, 3), Random.Range(2f, 3f));
            yield return new WaitForSeconds(_delay);
        }
    }

    private Vector2 RandomOnCircle(float radius)
    {
        float angle = Random.Range(0f, 360f);
        float cos = Mathf.Cos(Mathf.PI * angle / 180f);
        float sin = Mathf.Sin(Mathf.PI * angle / 180f);
        Vector2 normilizeDirection = new Vector2(cos, sin);
        return normilizeDirection * radius;
    }
}

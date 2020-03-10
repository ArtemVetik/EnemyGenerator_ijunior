using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    private Transform _target;
    private int _health;
    private float _moveSpeed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
    }

    public void Init(Transform target, int health, float moveSpeed)
    {
        _target = target;
        _health = health;
        _moveSpeed = moveSpeed;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable obj))
        {
            obj.ApplyDamage(1);
            if (obj is Spaceship)
                Destroy(gameObject);
        }
    }
}

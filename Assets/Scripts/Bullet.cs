using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _moveSpeed;

    private void Start()
    {
        _moveSpeed = 5f;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable obj))
        {
            obj.ApplyDamage(1);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

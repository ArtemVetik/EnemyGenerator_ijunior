using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour, IDamageable
{
    [SerializeField] Bullet _template;
    [SerializeField] Transform _firePosition;
    [SerializeField] float _angularSpeed;
    [SerializeField] int _health;

    public event Action OnApplyDamage;

    public int Health => _health;

    private void Update()
    {
        LookAt(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_template, _firePosition.position, transform.rotation);
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (Health <= 0)
        {
            _health = 0;
            gameObject.SetActive(false);
        }
        OnApplyDamage?.Invoke();
    }

    private void LookAt(Vector3 target)
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(target) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _angularSpeed * Time.deltaTime);
    }
}

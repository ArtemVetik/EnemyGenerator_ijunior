using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Spaceship _ship;

    private Text _health;

    private void OnEnable()
    {
        _ship.OnApplyDamage += UpdateHealth;
    }

    private void Awake()
    {
        _health = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void OnDisable()
    {
        _ship.OnApplyDamage -= UpdateHealth;
    }

    private void UpdateHealth()
    {
        _health.text = _ship.Health.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("LIFE PLAYER")]
    public int startLife = 10;

    public bool destroyOnKill = false;
    public float delayToKill = .1f;

    private float _currentLife;
    private bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }
     private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
            Debug.Log("Player is Dead!");
        }
    }
}

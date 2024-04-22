using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBase : MonoBehaviour
{
    //public Action<T> OnKill;

    [Header("LIFE PLAYER")]
    public int startLife = 10;

    public bool destroyOnKill = false;
    public float delayToKill = .05f;

    private float _currentLife;
    private bool _isDead = false;

    [SerializeField]
    private FlashColors _flashColors;

    private void Awake()
    {
        Init();
        if(_flashColors == null)
        {
            _flashColors = GetComponent<FlashColors>();
        }
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

        if(_flashColors != null)
        {
            _flashColors.Flash();
        }
    }
     private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
            //Debug.Log("Player is Dead!");
        }
        //OnKill.Invoke();
    }
}

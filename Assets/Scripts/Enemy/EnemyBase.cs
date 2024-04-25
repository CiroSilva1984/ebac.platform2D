using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public HealthBase healthBase;

    [Header("Animation Enemy")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Death";

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill();
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }

    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }
}

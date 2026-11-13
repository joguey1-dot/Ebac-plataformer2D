using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Combat Setup")]
    public int maxLife = 3;           
    private int currentLife;          
    public int damage = 10;           

    [Header("Animation Setup")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";

    private bool _isDead = false;

    private void Awake()
    {
        
        currentLife = maxLife;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead) return;

        var playerHealth = collision.gameObject.GetComponent<HealthBase>();

        
        if (playerHealth != null && collision.gameObject != gameObject)
        {
            playerHealth.Damage(damage);
            PlayAttackAnimation();
        }
    }

    
    public void Damage(int amount)
    {
        if (_isDead) return;

        currentLife -= amount;

        
        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerAttack);
        }
    }

    private void Die()
    {
        _isDead = true;

      
        if (animator != null)
        {
            animator.SetTrigger(triggerDeath);
        }

        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }

 
        Destroy(gameObject, 1f);
    }
}
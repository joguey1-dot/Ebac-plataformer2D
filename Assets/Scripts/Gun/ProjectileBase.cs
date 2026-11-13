using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10f;
    public string enemyTag = "Enemy";
    public int damageToGive = 1;

    private float _direction = 1f;

    private void Start()
    {
        if (myRigidbody == null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

       
        myRigidbody.velocity = new Vector2(speed * _direction, 0f);

        
        Destroy(gameObject, 3f);
    }
    public void SetDirection(float dir)
    {
        _direction = dir;

        if (dir < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.Damage(damageToGive);
            }

            Destroy(gameObject);
        }
    }
}
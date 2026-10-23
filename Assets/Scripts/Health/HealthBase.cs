using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int Startlife = 10;

    public bool destroyOnKill = false;

    public float delayToKill = 0f;


    private int _currenntLife;
    private bool _isDead = false; 

    private void Awake()
    {
        Init();
    }


    private void Init()
    {
        _isDead = false;
        _currenntLife = Startlife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currenntLife -= damage;

        if (_currenntLife <= 0)
        {
            kill();
        }
    }

    private void kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}

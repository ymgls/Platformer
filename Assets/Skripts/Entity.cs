using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int lives;

    public int Lives
    {
        get => lives;
        set
        {
            lives = value;
            if (value < 1)
            {
                Die();
            }
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        Lives -= damageAmount;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        // Логика инициализации
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int Lives { get; set; }

    public virtual void TakeDamage()
    {
        Lives--;
        if (Lives < 1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
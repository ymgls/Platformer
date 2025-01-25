using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 3;
    private void Start()
    {
        lives = 2;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
            lives--;
            Debug.Log($"Червяк: осталось {lives} жизни.");
        }

        if (lives < 1)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
   
}

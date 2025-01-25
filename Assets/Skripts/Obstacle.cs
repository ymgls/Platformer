using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Entity
{
    private void Start()
    {
        lives = 2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}

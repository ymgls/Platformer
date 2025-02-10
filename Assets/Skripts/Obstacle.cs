using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Entity
{
    protected override void Start()
    {
        base.Start();
        Lives = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}
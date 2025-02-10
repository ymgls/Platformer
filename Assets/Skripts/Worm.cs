using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField]
    private int maxLives = 3;

    protected override void Start()
    {
        base.Start();
        Lives = maxLives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
            Lives--;
            Debug.Log($"Червяк: осталось {Lives} жизни.");
        }

        if (Lives < 1)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
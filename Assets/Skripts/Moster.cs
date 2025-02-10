using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField]
    private float speed = 3f;

    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        direction = transform.right;
        Lives = 5;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            transform.position + transform.up * 0.1f + transform.right * direction.x * 0.7f,
            0.1f
        );

        if (colliders.Length > 0)
        {
            direction *= -1;
        }

        transform.position += direction * speed * Time.deltaTime;
        spriteRenderer.flipX = direction.x > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}
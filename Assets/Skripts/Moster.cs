using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private float speed = 3f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        dir = transform.right;
        lives = 5;
    }
    private void Update()
    {
        
        Move();
    }
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);
        if (colliders.Length > 0) dir *= -1;
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        }
        sprite.flipX = dir.x > 0;
    }   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
        }
    }
}
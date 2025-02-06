using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterScan : Entity
{
    private SpriteRenderer sprite;
    [SerializeField] private AIPath aiPath;
    
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        lives = 2;
    }

   
    void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x <= 0.01f;
    }
}

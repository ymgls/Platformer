using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity entity = other.GetComponent<Entity>();
        if (entity != null && entity.transform.position.y > transform.position.y)
        {
            entity.Die();
        }
    }
}
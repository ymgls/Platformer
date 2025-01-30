using UnityEngine;
using UnityEngine.UI;

public class LogoMove : MonoBehaviour
{
    public float speed = 0.5f; 
    private Vector3 startPosition; 
    private bool movingUp = true; 
    public float movementRange = 1f; 

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        
        float topBoundary = startPosition.y + movementRange;
        float bottomBoundary = startPosition.y - movementRange;

        if (transform.position.y > topBoundary)
        {
            movingUp = false; 
        }
        else if (transform.position.y < bottomBoundary)
        {
            movingUp = true; 
        }

        
        if (movingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
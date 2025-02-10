using UnityEngine;
using UnityEngine.UI;

public class LogoMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private float movementRange = 1f;

    private Vector3 startPosition;
    private bool movingUp = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float topBoundary = startPosition.y + movementRange;
        float bottomBoundary = startPosition.y - movementRange;

        if (transform.position.y >= topBoundary)
        {
            movingUp = false;
        }
        else if (transform.position.y <= bottomBoundary)
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
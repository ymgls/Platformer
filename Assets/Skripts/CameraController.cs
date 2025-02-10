using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        Vector3 position = player.position;
        position.z = -10f;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
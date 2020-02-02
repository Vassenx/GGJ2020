using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        var newPos = new Vector3(player.transform.position.x,
            player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
    }
}

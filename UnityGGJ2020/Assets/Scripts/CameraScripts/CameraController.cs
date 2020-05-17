using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    private float smoothSpeed = 0.125f;

    public FadeToBlack blackBlock;
    private bool following;

    private GameObject focus;

    void FixedUpdate()
    {
        if (focus == null)
        {
            focus = player;
        }

        if (!following)
        {
            var newPos = new Vector3(focus.transform.position.x,
                focus.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
        else if (blackBlock.visible)
        {
            blackBlock.FadeIn();
        }
        else
        {
            following = true;
        }
    }

    public void focusOnPlayer()
    {
        focus = player;
    }

    public void focusOnObject(GameObject focusObject)
    {
        focus = focusObject;
        following = true;
    }
}

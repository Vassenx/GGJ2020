using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCharacter : MonoBehaviour
{
    public static readonly string[] staticDirections =
    {
        "S_N",
        "S_NW",
        "S_W",
        "S_SW",
        "S_S",
        "S_SE",
        "S_E",
        "S_NE",
    };

    public static readonly string[] dynamicDirections =
{
        "D_N",
        "D_NW",
        "D_W",
        "D_SW",
        "D_S",
        "D_SE",
        "D_E",
        "D_NE",
    };

    Animator anim;
    public int lastDir;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lastDir = 3;
        SetDirection(Vector2.zero);
    }

    public void SetDirection(Vector2 direction)
    {
        string[] dirArray = null;

        if (direction.magnitude < 0.01f)
        {
            dirArray = staticDirections;
        }
        else
        {
            dirArray = dynamicDirections;
            lastDir = DirectionToIndex(direction, 8);
        }

        anim.Play(dirArray[lastDir]);
    }

    public void SetDirectionStanding()
    {
        anim.Play(staticDirections[lastDir]);
    }

    public static int DirectionToIndex(Vector2 dir, int count)
    {
        Vector2 normDir = dir.normalized;

        float step = 360f / count;

        float half = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle += half;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;

        return Mathf.FloorToInt(stepCount);
    }

}

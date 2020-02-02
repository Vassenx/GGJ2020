using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riseAndDestroy : MonoBehaviour
{
    private Vector3 hold;
    public float life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hold = gameObject.transform.position;
        hold.y += 10f * Time.deltaTime;
        gameObject.transform.position = hold;

        life -= 1f;
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }
}

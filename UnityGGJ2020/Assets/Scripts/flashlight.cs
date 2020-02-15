using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flashlight : MonoBehaviour
{
    IsoCharacter iso;
    Vector3 hold;

    // Start is called before the first frame update
    void Start()
    {
        iso = gameObject.GetComponentInParent<IsoCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
            hold = transform.rotation.eulerAngles;
            hold.z = (iso.lastDir * 45f);

            transform.rotation = Quaternion.Euler(hold.x, hold.y, hold.z);


        //hold = (iso.lastDir * 45f);

        //light.fall = new Vector2(1, 1);
    }
}

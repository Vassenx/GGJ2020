using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSystem : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Debug.Log("HIT AN OBJECT");
            Interactable target = hit.transform.gameObject.GetComponent<Interactable>();
            
            if(Input.GetMouseButtonDown(0))
            {
                target.ClickInteract();
            }
            else
            {
                target.HoverInteract();
            }
        }
    }
}

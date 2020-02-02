using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    [SerializeField] private DialogSystem dialogSystem = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject.GetComponent<Text>() != null)
                {
                    //TODO: find out which option was hit
                    //dialogSystem.onSelectOption(option);
                }
            }
        }
    }
}

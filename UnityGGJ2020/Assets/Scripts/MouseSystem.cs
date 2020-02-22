using UnityEngine;

public class MouseSystem : MonoBehaviour
{
    [SerializeField] private Camera cam;
    RaycastHit2D rayHit;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));

        if(rayHit.collider != null)
        {
            
            Interactable target = rayHit.transform.gameObject.GetComponent<Interactable>();
            
            if(Input.GetMouseButtonDown(0) && target != null)
            {
                target.ClickInteract();
            }
            else if(target != null)
            {
                target.HoverInteract();
            }
        }
    }
}

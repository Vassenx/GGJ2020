using UnityEngine;

public class LadderPickup : MonoBehaviour
{
    // [SerializeField] private Item item;
    [SerializeField] private GameObject player = null;
    public GameObject exitObject;
    public bool open;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open) {
                if (Vector2.Distance(player.transform.position, transform.position) <= 20f)
                {
                    exitObject.SetActive(false);
                    player.transform.position = exitObject.transform.position;
                    exitObject.SetActive(true);
                    exitObject.GetComponent<LadderPickup>().open = true;
                    open = false;
                }
            }
        }
    }
}

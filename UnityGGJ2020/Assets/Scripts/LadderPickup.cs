using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LadderPickup : MonoBehaviour
{
    // [SerializeField] private Item item;
    [SerializeField] private GameObject player = null;
    public GameObject destinationSign;
    public GameObject exitObject;
    public bool open;
    public string destinationName;

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


                    if (destinationSign.GetComponent<DestinationSign>().show != true)
                    {
                        destinationSign.GetComponentInChildren<TextMeshProUGUI>().text = destinationName;
                        destinationSign.GetComponent<DestinationSign>().show = true;
                    }
                    else
                    {
                        destinationSign.GetComponentInChildren<TextMeshProUGUI>().text = destinationName;
                        destinationSign.GetComponent<DestinationSign>().queued = true;
                    }
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class LadderPickup : MonoBehaviour
{
    // [SerializeField] private Item item;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject exitObject = null;
    [SerializeField] public string destinationName = null;

    [SerializeField] private Tilemap doorTileMap = null;
    [SerializeField] private int[][] doorLocation = null;
    [SerializeField] private Tile[] doorTiles = null;

    public GameObject destinationSign;
    private bool open;

    private void Start()
    {
        if (open)
        {
            openDoor();
        }
        else
        {
            closeDoor();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open)
            {
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

    public void openDoor()
    {
        open = true;

        if (doorTileMap != null)
        {
            for (int i = 0; i < doorTiles.Length; i++)
            {
                doorTileMap.SetTile(new Vector3Int(doorLocation[i][0], doorLocation[i][1], 0), null);
            }
        }
    }

    public void closeDoor()
    {
        open = false;

        if (doorTileMap != null)
        {
            for (int i = 0; i < doorTiles.Length; i++)
            {
                doorTileMap.SetTile(new Vector3Int(doorLocation[i][0], doorLocation[i][1], 0), doorTiles[i]);
            }
        }
    }
}

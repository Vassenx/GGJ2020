using UnityEngine;

public class LadderPickup : MonoBehaviour, Interactable
{
    // [SerializeField] private Item item;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject exitObject;

    public void HoverInteract()
    {
        //teleport the player up the stairs or start animation
        //player.transform.position = ;

    }

    public void ClickInteract()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyInteract();
        }
    }

    public void KeyInteract()
    {
        if(Vector2.Distance(player.transform.position, transform.position) <= 40f)
        {
            player.transform.position = exitObject.transform.position;
        }
    }
}

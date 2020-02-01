using UnityEngine;

public class LadderPickup : Interactable
{
    // [SerializeField] private Item item;
    [SerializeField] private GameObject player;
    
    protected override void Interact()
    {
        base.Interact();

        //teleport the player up the stairs or start animation
        //player.transform.position = ;
    }
}

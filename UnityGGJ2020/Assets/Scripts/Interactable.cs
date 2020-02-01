using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 1f;

    protected virtual void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        //implement me
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
}

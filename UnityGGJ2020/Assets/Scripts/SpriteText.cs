using UnityEngine;

//sorts the text mesh to be the same layer as the sprite parent
public class SpriteText : MonoBehaviour
{
    [SerializeField] private Renderer parentRend = null;

    void Start()
    {
        var parent = transform.parent;

        var renderer = GetComponent<Renderer>();
        if (parentRend == null)
        {
            parentRend = parent.GetComponent<Renderer>();
        }
        renderer.sortingLayerID = parentRend.sortingLayerID;
        renderer.sortingOrder = parentRend.sortingOrder;

        var text = GetComponent<TextMesh>();
        text.text = string.Format(text.text);
    }
}

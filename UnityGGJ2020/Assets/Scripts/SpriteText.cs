using UnityEngine;

//sorts the text mesh to be the same layer as the sprite parent
public class SpriteText : MonoBehaviour
{
    void Start()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;

        var text = GetComponent<TextMesh>();
        text.text = string.Format(text.text);
    }
}

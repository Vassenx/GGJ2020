using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Tool")]
public class ItemData : ScriptableObject
{
    public Sprite uiSprite;
    public Tool toolAsset;
    [SerializeField] private string description;
}

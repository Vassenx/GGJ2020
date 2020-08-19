using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Tool")]
public class ItemData : ScriptableObject
{
    public Sprite uiSprite;
    public Tool toolAsset;
    public TMP_Text description;

}


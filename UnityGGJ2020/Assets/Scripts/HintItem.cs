using UnityEngine;


[CreateAssetMenu(menuName = "hintObjects")]

public class HintItem : ScriptableObject
{
    public Sprite hintSprite;
    public Hints hints;
    [SerializeField] private string description;
}

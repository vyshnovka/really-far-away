using UnityEngine;
using UnityEngine.U2D.Animation;

public enum ClothesType
{
    Shirt,
    Pants,
    Shoes,
    MakeUp
}

[CreateAssetMenu(fileName = "Clothes", menuName = "Scriptable Objects/Clothes")]
public class Clothes : ScriptableObject
{
    public string description;
    public ClothesType type;
    public Sprite icon;
    public int price;
    public SpriteLibraryAsset sprites;
}

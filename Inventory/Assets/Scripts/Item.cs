using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    [Serializable] public enum Type { armor, weapon, empty };
    [Serializable] public enum Rarity { common, rare, veryRare, epic, legendary, empty}

    public Sprite itemImage;
    [NonSerialized] public Sprite backgroundImage;
    public string Name;
    public string description;
    public int price;
    public Type type;
    public string subType;
    public Rarity rarity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public Sprite itemImage;
    public Sprite backgroundImage;
    public string Name;
    public string description;
    public int price;
    public Type type;
    public enum Type
    {
        armor,
        weapon
    };
}

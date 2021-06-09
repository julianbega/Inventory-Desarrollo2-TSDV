using System;
using UnityEngine;

public class Equipment : Item
{
    public int maxDurability;
    public int actualDurability;
    [NonSerialized] public GameObject InGameForm;
}

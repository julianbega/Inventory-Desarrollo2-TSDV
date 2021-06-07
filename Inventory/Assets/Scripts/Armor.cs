using UnityEngine;

[CreateAssetMenu(fileName = "Armor")]
public class Armor : Equipment
{
    public enum SubType
    {
        front, helmet, arms, legs
    }
    public SubType armorType;
    public int defenseBonus;
    public int hpBonus;
}

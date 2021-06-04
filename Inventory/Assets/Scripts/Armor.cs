using UnityEngine;

[CreateAssetMenu(fileName = "Armor")]
public class Armor : Equipment
{
    public enum Type
    {
        front, helmet, arms, legs
    }
    public Type armorType;
    public int defenseBonus;
    public int hpBonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    enum Rarity
    {
        common = 1, rare, veryRare,Epic,Legendary
    }
    [Range (1,5)]
    public int rarity;
    public int maxDurability;
    public int actualDurability;
    public MeshRenderer Renderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

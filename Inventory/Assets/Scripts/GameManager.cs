using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player myPlayer;
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        myPlayer = LoadInfo();
    }

    private void OnDisable()
    {
        SaveInfo(myPlayer);
    }
    public static void SaveInfo(Player myPlayer)
    {
        string json = JsonUtility.ToJson(myPlayer);
        PlayerPrefs.SetString("PlayerInfo",json);
    }

    public static Player LoadInfo()
    {        
        Player myPlayer = FindObjectOfType<Player>();
        string jsonData = PlayerPrefs.GetString("PlayerInfo");
        JsonUtility.FromJsonOverwrite(jsonData, myPlayer);
        return myPlayer;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SaveInfo(myPlayer);
        }
        if (Input.GetKey(KeyCode.L))
        {
            myPlayer = LoadInfo();
        }
    }
}

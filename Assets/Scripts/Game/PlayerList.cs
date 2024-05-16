using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviourPunCallbacks
{
    public Text playerName;
    public static PlayerList instance;
    public static int playersCount;
    public static List<Player> players;
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

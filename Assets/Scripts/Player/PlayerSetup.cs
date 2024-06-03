using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour
{
    public GameObject cam;
    public PlayerMovement mScript;
    public PlayerCamera cScript;
    public Text nick;
    public GameObject player;

    public void Initialize()
    {
        mScript.enabled = true;
        cScript.enabled = true;
        cam.SetActive(true);
        nick.text = player.GetComponent<PhotonView>().Controller.NickName;
    }
}

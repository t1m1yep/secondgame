using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    public GameObject cam;
    public PlayerMovement mScript;
    public PlayerCamera cScript;
    public Text nick;

    public void Initialize()
    {
        mScript.enabled = true;
        cScript.enabled = true;
        cam.SetActive(true);
        nick.text = gameObject.GetComponent<PhotonView>().Owner.NickName;
    }
}

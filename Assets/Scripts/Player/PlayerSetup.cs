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
    public GameObject player;

    public GameObject assignedSpawn;

    public void Initialize()
    {
        mScript.enabled = true;
        cScript.enabled = true;
        cam.SetActive(true);
        nick.text = player.GetComponent<PhotonView>().Controller.NickName;
    }

    private void Start() {
        if(photonView.IsMine) {
            nick.gameObject.SetActive(false);
        }
        if(!photonView.IsMine) {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void Update() {
        nick.text = gameObject.GetComponent<PhotonView>().Owner.NickName;
        ShowNickname();
    }

    private void ShowNickname() {
        Camera camera = (Camera)FindObjectOfType(typeof(Camera));
        if(camera) {
            nick.gameObject.transform.LookAt(camera.gameObject.transform);
        }
    }
}

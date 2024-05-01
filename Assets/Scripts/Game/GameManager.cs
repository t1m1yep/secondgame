using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject ply;
    public Transform spawnpoint;
    public GameObject escapeMenu;
    
    private void Start() {
        escapeMenu.SetActive(false);
        LoadPlayer();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            escapeMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Exit()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }
    
    public void LoadPlayer() {
        GameObject player = PhotonNetwork.Instantiate("Player", spawnpoint.position, spawnpoint.rotation);
        player.GetComponent<PlayerSetup>().Initialize();
    }
}

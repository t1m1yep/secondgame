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
    public List<GameObject> players;
    
    private void Start() {
        escapeMenu.SetActive(false);
        LoadPlayer();
        PhotonNetwork.EnableCloseConnection = true;
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
        if (PhotonNetwork.IsMasterClient)
        {
            foreach (GameObject plyModel in players)
            {
                PhotonNetwork.Destroy(plyModel);
            }
            foreach (var pair in PhotonNetwork.CurrentRoom.Players)
            {
                PhotonNetwork.CloseConnection(pair.Value);
            }
        }
        PhotonNetwork.LoadLevel(0);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene(0);
    }

    public void LoadPlayer() {
        GameObject player = PhotonNetwork.Instantiate("Player", spawnpoint.position, spawnpoint.rotation);
        player.GetComponent<PlayerSetup>().Initialize();
        players.Add(player);
    }
}

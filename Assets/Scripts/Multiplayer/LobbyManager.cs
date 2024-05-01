using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Multiplayer
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {

        public Text roomNameInputBox;
        public Text playerNameInputBox;
        public Transform roomList;
        public Button roomButtonPrefab;
        public static LobbyManager instance;
        private void Start()
        {
            //Debug.Log("[!] Connecting to server.");
            PhotonNetwork.ConnectUsingSettings();
            MenuManager.instance.ToggleMenu("Loading");
            instance = this;
        }
        
        public override void OnConnectedToMaster()
        {
            Debug.Log("[+] Connected to master");
            PhotonNetwork.JoinLobby();
        }

        public void CreateRoom() {
            string name = roomNameInputBox.text.Length == 0 ?  "Room"+Random.Range(0, 100).ToString() : roomNameInputBox.text;
            PhotonNetwork.CreateRoom(name);
            MenuManager.instance.ToggleMenu("Room");
            Debug.Log("[+] Creating room with name "+ name);
        }

        public void JoinRoom(string name)
        {
            PhotonNetwork.JoinRoom(name);
        }
        
        public override void OnRoomListUpdate(List<RoomInfo> _rooms)
        {
            for (int i = 0; i < roomList.childCount; i++)
            {
                Destroy(roomList.GetChild(i).gameObject);
            }
            for (int i = 0; i < _rooms.Count; i++)
            {
                Instantiate(roomButtonPrefab, roomList).GetComponent<RoomButton>().Setup(_rooms[i]);
            }
        }
  
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby(); 
            Debug.Log("[+] Connected to lobby");
            MenuManager.instance.ToggleMenu("Main");
        }
        public override void OnJoinedRoom() 
        {
            base.OnJoinedRoom();
            string name = playerNameInputBox.text.Length == 0 ? "Player"+Random.Range(0, 100).ToString() : playerNameInputBox.text;
            PhotonNetwork.NickName = name;
            Debug.Log("[+] Joined room with nickname "+name);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            base.OnMasterClientSwitched(newMasterClient);
            
        }
    }
}   


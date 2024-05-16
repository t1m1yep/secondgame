using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class RoomButton : MonoBehaviourPunCallbacks
    {
        public Text roomText;
        public Text hostName;
        public Text playersText;
        public RoomInfo roomInfo;

        public void Setup(RoomInfo info)
        {
            roomInfo = info;
            roomText.text = roomInfo.Name;
            hostName.text = info.CustomProperties["Hostname"].ToString();
            playersText.text = info.PlayerCount.ToString() + "/" + info.MaxPlayers.ToString();
        }
        

        public void OnClick()
        {
            LobbyManager.instance.JoinRoom(roomInfo.Name);
        }
    }
}
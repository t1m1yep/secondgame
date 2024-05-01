using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class RoomButton : MonoBehaviour
    {
        public Text roomText;
        public RoomInfo roomInfo;

        public void Setup(RoomInfo info)
        {
            roomInfo = info;
            roomText.text = roomInfo.Name;
        }

        public void OnClick()
        {
            LobbyManager.instance.JoinRoom(roomInfo.Name);
        }
    }
}
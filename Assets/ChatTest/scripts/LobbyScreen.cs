using UnityEngine;
using System.Collections;

public class LobbyScreen : MonoBehaviour {
    Vector2 lobbyScroll = Vector2.zero;

    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;
    }
	
    void OnGUI()
    {
        if(GUILayout.Button("Join Random", GUILayout.Width(200f)))
        {
            PhotonNetwork.JoinRandomRoom();
        }

        if (GUILayout.Button("Create Room", GUILayout.Width(200f)))
        {
            PhotonNetwork.CreateRoom(PlayerPrefs.GetString("Username") + "'s Room", true, true, 32);
        }

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if(rooms.Length == 0)
        {
            GUILayout.Label("No Rooms Available");
        }
        else
        {
            lobbyScroll = GUILayout.BeginScrollView(lobbyScroll, GUILayout.Width(220f), GUILayout.ExpandHeight(true));
        }
        foreach(RoomInfo room in PhotonNetwork.GetRoomList())
        {
            GUILayout.Label(room.name + " - " + room.playerCount + "/" + room.maxPlayers);
            if(GUILayout.Button("Enter"))
            {
                PhotonNetwork.JoinRoom(room.ToString());
            }
            GUILayout.EndHorizontal();
        }
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(PlayerPrefs.GetString("Username") + "'s Room", true, true, 32);
    }

    void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel("ChatRoom");
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatRoom : Photon.MonoBehaviour {

    public int MaxMessages = 100;

    private Vector2 chatScroll = Vector2.zero;
    private List<string> chatMessages = new List<string>();
    private string message = "";

    void OnGUI()
    {
        if(GUILayout.Button("Leave Room"))
        {
            PhotonNetwork.LeaveRoom();
        }

        chatScroll = GUILayout.BeginScrollView(chatScroll, GUILayout.Width(Screen.width), GUILayout.ExpandHeight(true));

        foreach(string msg in chatMessages)
        {
            GUILayout.Label(msg);
        }

        GUILayout.EndScrollView();
        GUILayout.BeginHorizontal();

        message = GUILayout.TextField(message, GUILayout.ExpandWidth(true));

        if(GUILayout.Button("Send", GUILayout.Width(100f)))
        {
            photonView.RPC("AddChat", PhotonTargets.All, message);
            message = "";
        }

        GUILayout.EndHorizontal();
    }
    
    [RPC]
    void AddChat(string message, PhotonMessageInfo info)
    {
        chatMessages.Add(info.sender.name + ": " + message);

        if(chatMessages.Count > MaxMessages)
        {
            chatMessages.RemoveAt(0);
        }
        chatScroll.y = 10000;
    }

    void OnLeftRoom()
    {
        Application.LoadLevel("Main");
    }
}

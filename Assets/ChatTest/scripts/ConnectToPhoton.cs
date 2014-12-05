using UnityEngine;
using System.Collections;

public class ConnectToPhoton : MonoBehaviour {

    public GameObject LobbyScreen;
    private string username = "";
    private bool connecting = false;
    private string error = null;
    

	void Start () 
    {
        username = PlayerPrefs.GetString("Username", "");
	}
	
	void OnGUI()
    {
        if(connecting)
        {
            GUILayout.Label("Connecting...");
            return;
        }
        if(error != null)
        {
            GUILayout.Label("Shit broke and this is why: " + error);
            return;
        }

        GUILayout.Label("Username");
        username = GUILayout.TextField(username, GUILayout.Width(200f));

        if(GUILayout.Button("Connect"))
        {
            PlayerPrefs.SetString("Username", username);

            connecting = true;

            PhotonNetwork.playerName = username;
            PhotonNetwork.ConnectUsingSettings("v1.0");
        }
    }

    void OnJoinedLobby()
    {
        connecting = false;
        //Todo: Fix this
        gameObject.SetActiveRecursively(false);
        LobbyScreen.SetActiveRecursively(true);
    }

    void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        connecting = false;
        error = cause.ToString();
    }
}

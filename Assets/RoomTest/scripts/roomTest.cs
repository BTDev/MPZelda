using UnityEngine;
using System.Collections;

public class roomTest : MonoBehaviour {
   
    void Awake()
    {
        PhotonNetwork.Instantiate("PlayerCharacter", Vector3.zero, Quaternion.identity, 0);
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

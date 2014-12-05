using UnityEngine;
using System.Collections;

public class playerNetwork : Photon.MonoBehaviour 
{

    playerController controllerScript;

	void Awake () 
    {
        controllerScript = GetComponent<playerController>();

        if (photonView.isMine)
        {
            //MINE: local player, simply enable the local scripts
            controllerScript.enabled = true;
        }
        else
        {
            controllerScript.enabled = true;
            controllerScript.isControllable = false;
        }

        gameObject.name = gameObject.name + photonView.viewID;
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(transform.position);
        }
        else
        {
            //Network player, receive data
            correctPlayerPos = (Vector3)stream.ReceiveNext();
        }
    }

    private Vector3 correctPlayerPos = Vector3.zero; //We lerp towards this

    void Update()
    {
        if (!photonView.isMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            controllerScript.position = Vector2.Lerp(controllerScript.position, correctPlayerPos, Time.deltaTime * 15);
        }
    }
}

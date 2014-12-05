using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    private Vector2 position;
    public bool isControllable = true;
	// Use this for initialization

	void Start () 
    {
        position = this.gameObject.transform.position;
	}
	
    void Update()
    {
        if (isControllable)
        {
            if (Input.GetKey(KeyCode.W))
            {
                position.y += 0.2f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                position.y -= 0.2f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                position.x -= 0.2f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                position.x += 0.2f;
            }
        }

        CharacterController controller = GetComponent<CharacterController>();
        controller.Move(position);

        this.gameObject.transform.position = position;
    }
}

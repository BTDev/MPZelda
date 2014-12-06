using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public Vector2 position;
    public bool isControllable = true;

    protected Animator animator;

	void Start () 
    {
        position = this.gameObject.transform.position;
        animator = GetComponent<Animator>();
	}
	
    void Update()
    {
        if (isControllable)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalk", true);
                animator.SetInteger("direction", 0);
                position.y += 0.2f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalk", true);
                animator.SetInteger("direction", 1);
                position.y -= 0.2f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalk", true);
                animator.SetInteger("direction", 2);
                position.x -= 0.2f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalk", true);
                animator.SetInteger("direction", 3);
                position.x += 0.2f;
            }
            else
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isWalk", false);
            }
        }

        this.gameObject.transform.position = position;
    }
}

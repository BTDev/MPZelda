using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public Vector2 position;
    public bool isControllable = true;

    private Animator animator;

    void move(int direction)
    {
        if (direction == 0)
        {
            position.y -= 0.2f;
        }
        else if (direction == 1)
        {
            position.x -= 0.2f;
        }
        else if (direction == 2)
        {
            position.y += 0.2f;
        }
        else if(direction == 3)
        {
            position.x += 0.2f;
        }
    }

	void Start () 
    {
        position = this.gameObject.transform.position;
        animator = GetComponent<Animator>();
	}
	
    void Update()
    {
        if (isControllable)
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            var direction = 0;
            animator.SetBool("Attack", false);
            animator.enabled = true;

            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("Attack", true);
            }
            else if (vertical > 0)
            {
                if (!isAttacking())
                {
                    direction = 2;
                    animator.SetInteger("Direction", direction);
                    move(direction);
                }

            }
            else if (vertical < 0)
            {
                if (!isAttacking())
                {
                    direction = 0;
                    animator.SetInteger("Direction", direction);
                    move(direction);
                }

            }
            else if (horizontal > 0)
            {
                if (!isAttacking())
                {
                    direction = 3;
                    animator.SetInteger("Direction", direction);
                    move(direction);
                }
            }
            else if (horizontal < 0)
            {
                if (!isAttacking())
                {
                    direction = 1;
                    animator.SetInteger("Direction", direction);
                    move(direction);
                }

            }
            else
            {
                if (!isAttacking())
                {
                    animator.SetBool("Attack", false);
                    animator.enabled = false;
                }
            }
        }

        this.gameObject.transform.position = position;
    }

    public bool isAttacking()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attackEast") || 
            animator.GetCurrentAnimatorStateInfo(0).IsName("attackWest") || 
            animator.GetCurrentAnimatorStateInfo(0).IsName("attackNorth") || 
            animator.GetCurrentAnimatorStateInfo(0).IsName("attackSouth"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 5;
    private Animator animator;
    private GameObject character;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GameObject.Find("Knight Character");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -1;
            character.transform.localScale.Set(-1, 1, 1);
            animator.SetInteger("Direction", 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = 1;
            animator.SetInteger("Direction", 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -1;
            animator.SetInteger("Direction", 3);
        }

        // look for attack commands
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Swing");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Thrust");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("Bow");
        }

        // detect idle state
        if ((Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.y)) == 0)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
            character.transform.Translate(moveDirection * speed * Time.deltaTime);
        }

    }
}

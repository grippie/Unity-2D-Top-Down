using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public GameObject downDir, upDir, leftDir, rightDir;
    public GameObject currentDir;
    public float speed;
    public bool isWalking;
    public float horizontal, vertical;
    public Camera cam;
    public float x, y, z;
 
    // Use this for initialization
    void Start()
    {

        if (currentDir == null)
        {
            if (downDir.activeSelf)
                currentDir = downDir;
            else if (upDir.activeSelf)
                currentDir = upDir;
            else if(rightDir.activeSelf)
                currentDir = rightDir;
            else if(leftDir.activeSelf)
                currentDir = leftDir;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.zero;
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isWalking = false;

        x = cam.transform.position.x;
        y = cam.transform.position.y;
        z = cam.transform.position.z;

        moveDirection.x = horizontal;
        moveDirection.y = vertical;

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
            isWalking = true;
        else
            isWalking = false;

        if (horizontal < 0)
        {
            if (!currentDir.Equals(leftDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                currentDir.SetActive(false);
                currentDir = leftDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }
        }
        if (vertical > 0)
        {
            if (!currentDir.Equals(upDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                currentDir.SetActive(false);
                currentDir = upDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }
        }
        else if (horizontal > 0)
        {
            if (!currentDir.Equals(rightDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                currentDir.SetActive(false);
                currentDir = rightDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }
            else
            {
                currentDir = rightDir;
            }
        }
        else if (vertical < 0)
        {
            if (!currentDir.Equals(downDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                currentDir.SetActive(false);
                currentDir = downDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentDir.GetComponent<Animator>().SetTrigger("Thrust");
            moveDirection.x = 0;
            moveDirection.y = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection.x = 0;
            moveDirection.y = 0;
            currentDir.GetComponent<Animator>().SetTrigger("Swing");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            moveDirection.x = 0;
            moveDirection.y = 0;
            currentDir.GetComponent<Animator>().SetTrigger("Bow");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            moveDirection.x = 0;
            moveDirection.y = 0;
            currentDir.GetComponent<Animator>().SetTrigger("Spell");
        }

        // detect for idle state, or move character
        if (!isWalking)
        {
            currentDir.GetComponent<Animator>().SetBool("Idle", true);
        }
        else
            transform.Translate(moveDirection * speed * Time.deltaTime);
    }


}

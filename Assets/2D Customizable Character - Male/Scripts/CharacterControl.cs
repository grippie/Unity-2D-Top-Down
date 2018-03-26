using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public GameObject downDir, upDir, leftDir, rightDir;
    public GameObject currentDir;
    public float speed = 7;
    public bool isWalking;
    public float horizontal, vertical;
 
    // Use this for initialization
    void Start()
    {
        if (currentDir == null)
            currentDir = downDir;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        //currentDirAnim = currentDir.GetComponent<Animator>();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isWalking = false;

        if (horizontal < 0)
        {
            isWalking = true;
            moveDirection.x = horizontal;

            if (!currentDir.Equals(leftDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))
            {
                currentDir.SetActive(false);
                currentDir = leftDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }  
        }
        else if (vertical > 0)
        {
            isWalking = true;
            moveDirection.y = 1;

            if (!currentDir.Equals(upDir))
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
            isWalking = true;
            moveDirection.x = 1;

            if (!currentDir.Equals(rightDir))
            {
                currentDir.SetActive(false);
                currentDir = rightDir;
                currentDir.SetActive(true);
                currentDir.GetComponent<Animator>().Play(0);
                currentDir.GetComponent<Animator>().SetBool("Idle", false);
            }
        }
        else if (vertical < 0)
        {
            isWalking = true;
            moveDirection.y = -1;

            if (currentDir != downDir)
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterControl : MonoBehaviour
{

    public GameObject downDir, upDir, leftDir, rightDir;
    public GameObject currentDir;
    public GameObject previousDir;
    public float speed;
    public bool isWalking;
    public float horizontal, vertical;
    public float x, y, z;
    private TilemapInfo ti;
    public Tilemap tilemap;

    // Use this for initialization
    void Start()
    {
        ti = tilemap.GetComponent<TilemapInfo>();

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

        moveDirection.x = horizontal;
        moveDirection.y = vertical;

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
            isWalking = true;
        else
            isWalking = false;

        // if not moving the same direction as before, or in idling state
        //if (!currentDir.Equals(previousDir) || currentDir.GetComponent<Animator>().GetBool("Idle"))

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

        previousDir = currentDir;
    }

    // happens after update
    void LateUpdate()
    {
        // clamps the player movement between tilemap (xMinimum + camerawidth / 2) etc
        // using the tilemapInfo.cs script to be reusable by every scene that has different sizes.
        transform.position = new Vector3(Mathf.Clamp(ti.target.position.x, ti.playerXmin, ti.playerXmax),
            Mathf.Clamp(ti.target.position.y, ti.playerYmin, ti.playerYmax), 0);
    }

}

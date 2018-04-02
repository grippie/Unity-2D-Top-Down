using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    Camera camera;

	// Use this for initialization
	void Start ()
    {
        camera = GetComponent<Camera>();
	}

    void FixedUpdate()
    {
        //if (camera.transform.position.x <= (1.77 / 2)
        //{
        //    camera.transform.position = new Vector2(1.57 / 2, 0);
        //}
            
    }
}

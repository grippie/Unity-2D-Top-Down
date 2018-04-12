using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    private TilemapInfo ti;
    public Tilemap tilemap;

    void Start()
    {
        ti = tilemap.GetComponent<TilemapInfo>();
    }

    // Update is called after Update
    void LateUpdate()
    {
        // moves the position of the camera only within the bounds of the tilemap size
        // clamps the camera movement between tilemap (xMinimum + camerawidth / 2) etc
        transform.position = new Vector3(Mathf.Clamp(ti.target.position.x, ti.cameraXmin, ti.cameraXmax),
            Mathf.Clamp(ti.target.position.y, ti.cameraYmin, ti.cameraYmax), -10);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float xMax, xMin, yMax, yMin, height, width;
    public Tilemap tilemap;
    public Camera cam;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetLimits(maxTile, minTile);
	}
	
	// Update is called after Update
	void LateUpdate ()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax ), -10);	
	}

    private void SetLimits(Vector3 maxTile, Vector3 minTile)
    {
        cam = Camera.main;

        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        // find the edges of the camera from the center point
        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}

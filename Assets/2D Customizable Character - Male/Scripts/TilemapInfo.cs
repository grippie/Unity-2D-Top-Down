using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInfo : MonoBehaviour {

    public Tilemap tilemap;
    public Camera cam;
    public GameObject player;
    public Transform target { get; set; }
    public float cameraXmax { get; set; }
    public float cameraXmin { get; set; }
    public float cameraYmax { get; set; }
    public float cameraYmin { get; set; }

    public float playerXmax { get; set; }
    public float playerXmin { get; set; }
    public float playerYmax { get; set; }
    public float playerYmin { get; set; }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        target = player.transform;
        tilemap = GetComponent<Tilemap>();

        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        // hardcoded :( trying to find out a way to get the prefab size. tried collider size, but 2d colliders
        // don't seem to work. 
        float playerSize = .435f;
        
        playerXmin = minTile.x + playerSize;
        playerXmax = maxTile.x - playerSize;

        playerYmin = minTile.y + playerSize;
        playerYmax = maxTile.y - playerSize;

        cameraXmin = minTile.x + (width / 2);
        cameraXmax = maxTile.x - (width / 2);

        cameraYmin = minTile.y + (height / 2);
        cameraYmax = maxTile.y - (height / 2);
    }
}

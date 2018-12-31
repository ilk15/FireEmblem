using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private float vSize, hSize;
    private GameObject tile;

    void Start()
    {
        vSize = 2*gameObject.GetComponent<Camera>().orthographicSize;
        hSize = vSize * gameObject.GetComponent<Camera>().aspect;
        tile = Adjacency.TileOf(gameObject);
        transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x< transform.position.x - hSize/2)
        {
            tile = Adjacency.TileLeft(tile);
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
        }
        else if (target.transform.position.x > transform.position.x + hSize / 2)
        {
            tile = Adjacency.TileRight(tile);
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
        }
        else if (target.transform.position.y < transform.position.y - vSize / 2)
        {
            tile = Adjacency.TileDown(tile);
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
        }
        else if (target.transform.position.y > transform.position.y + vSize / 2)
        {
            tile = Adjacency.TileUp(tile);
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, transform.position.z);
        }
    }
}

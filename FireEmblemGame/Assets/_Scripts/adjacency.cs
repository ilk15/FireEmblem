using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Adjacency
{
    public static float gridSize = 0.16f;

    public static List<GameObject> AdjacentTiles(GameObject currentTile)
    {
        List<GameObject> list = new List<GameObject>();
        if (currentTile.layer != 8)
        {
            
            return null;
        }
        else
        {
            foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position, gridSize * 0.6f))
            {
                if (col.gameObject.layer == 8)
                {
                    list.Add(col.gameObject);
                }
            }
            return list;
        }
    }

    public static GameObject TileUp(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position+new Vector3(0, gridSize,0), gridSize * 0.2f))
        {
            if (col.gameObject.layer == 8)
            {
                output = col.gameObject;
            }
        }
        return output;
    
    }

    public static GameObject TileDown(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position - new Vector3(0, gridSize, 0), gridSize * 0.2f))
        {
            if (col.gameObject.layer == 8)
            {
                output = col.gameObject;
            }
        }
        return output;

    }

    public static GameObject TileLeft(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position - new Vector3(gridSize, 0, 0), gridSize * 0.2f))
        {
            if (col.gameObject.layer == 8)
            {
                output = col.gameObject;
            }
        }
        return output;

    }

    public static GameObject TileRight(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position + new Vector3(gridSize, 0, 0), gridSize * 0.2f))
        {
            if (col.gameObject.layer == 8)
            {
                output = col.gameObject;
            }
        }
        return output;

    }

    public static GameObject UnitOn(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position, gridSize * 0.2f))
        {
            if (col.gameObject.layer == 9)
            {
                output = col.gameObject;
            }
        }
        return output;

    }

    public static GameObject TileOf(GameObject currentTile)
    {
        GameObject output = null;
        foreach (Collider2D col in Physics2D.OverlapCircleAll(currentTile.transform.position, gridSize * 0.2f))
        {
            if (col.gameObject.layer == 8)
            {
                output = col.gameObject;
            }
        }
        return output;

    }
}

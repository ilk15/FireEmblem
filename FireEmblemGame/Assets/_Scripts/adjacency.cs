using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class adjacency
{
    public static float gridSize = 0.16f;

    public static List<GameObject> adjacentTiles(GameObject currentTile)
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
}

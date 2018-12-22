using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridMaker : MonoBehaviour
{
    public float gridSize;
        
    private int hCells, vCells;

    public GameObject bottomLeft, topRight;

    public GameObject tilePrefab, tileHolder;

    bool active;

    public void make()
    {
        if (active)
            return;
        else
        {
            active = true;

            hCells = (int)(Math.Abs(bottomLeft.transform.position.x - topRight.transform.position.x) / gridSize);
            vCells = (int)(Math.Abs(bottomLeft.transform.position.y - topRight.transform.position.y) / gridSize);

            for (int i = 0; i < hCells; i++)
            {
                for (int j = 0; j < vCells; j++)
                {
                    GameObject tile = Instantiate(tilePrefab, new Vector3(bottomLeft.transform.position.x + i * gridSize, bottomLeft.transform.position.y + j * gridSize, bottomLeft.transform.position.z), Quaternion.identity, tileHolder.transform) as GameObject;
                }
            }

        }

    }


}

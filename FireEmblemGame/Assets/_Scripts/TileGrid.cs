using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileGrid : MonoBehaviour
{
    public float gridSize;

    private int hCells, vCells;

    public GameObject bottomLeft, topRight;

    public GameObject tilePrefab;

    private GameObject[,] grid;

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
            grid = new GameObject[hCells+1, vCells+1];
            for (int i = 0; i <= hCells; i++)
            {
                for (int j = 0; j <= vCells; j++)
                {
                    grid[i, j] = Instantiate(tilePrefab, new Vector3(bottomLeft.transform.position.x + i * gridSize, bottomLeft.transform.position.y + j * gridSize, bottomLeft.transform.position.z), Quaternion.identity, transform) as GameObject;
                }
            }
        }

    }


}

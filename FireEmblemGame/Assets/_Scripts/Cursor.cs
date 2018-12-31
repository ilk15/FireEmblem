using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public GameObject currentTile, currentUnit, selectedUnit;
    private float timePassed;
    private float delay = 0.3f;
    private bool active, selected = false; 

    // Start is called before the first frame update
    void Start()
    {

        currentTile = Adjacency.TileOf(gameObject);
        currentUnit = Adjacency.UnitOn(currentTile);
    }

    private void Update()
    {
        transform.position = currentTile.transform.position;
        currentTile = Adjacency.TileOf(gameObject);
        currentUnit = Adjacency.UnitOn(currentTile);
        timePassed = timePassed + Time.deltaTime;

        if (!active)
        {
            active = true;
            if (Input.GetAxis("Vertical") > 0 && Adjacency.TileUp(currentTile) != null && timePassed > delay)
            {
                currentTile = Adjacency.TileUp(currentTile);
                timePassed = 0;
            }
            else if (Input.GetAxis("Horizontal") < 0 && Adjacency.TileLeft(currentTile) != null && timePassed > delay)
            {
                currentTile = Adjacency.TileLeft(currentTile);
                timePassed = 0;
            }
            else if (Input.GetAxis("Vertical") < 0 && Adjacency.TileDown(currentTile) != null && timePassed > delay)
            {
                currentTile = Adjacency.TileDown(currentTile);
                timePassed = 0;
            }
            else if (Input.GetAxis("Horizontal") > 0 && Adjacency.TileRight(currentTile) != null && timePassed > delay)
            {
                currentTile = Adjacency.TileRight(currentTile);
                timePassed = 0;

            }

            if (Input.GetButtonDown("Submit") && currentUnit != null && ! selected && ! currentUnit.GetComponent<Unit>().HasActed())
            {
                selected = true;
                selectedUnit = currentUnit;
                Debug.Log("selected");
                foreach (GameObject tile in (selectedUnit.GetComponent<Unit>() as Unit).ReachableTiles())
                {
                    tile.GetComponent<SpriteRenderer>().enabled = true;
                }
            }

            if (Input.GetButtonDown("Submit") && currentUnit == null && selected)
            {
                if ((selectedUnit.GetComponent<Unit>() as Unit).ReachableTiles().Contains(currentTile))
                {
                    foreach (GameObject tile in (selectedUnit.GetComponent<Unit>() as Unit).ReachableTiles())
                    {
                        tile.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    selectedUnit.transform.position = currentTile.transform.position;
                    selected = false;
                    selectedUnit.GetComponent<Unit>().EndAction();

                }
                else 
                    Debug.Log("not in range");
                
            }

            active = false;
        }
    }


}

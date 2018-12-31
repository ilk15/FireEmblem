using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string Name;
    public string Class;
    public GameObject currentTile;

    public int Level;
    public int Exp;

    public int HP;
    public int Luck;
    public int Str;
    public int Def;
    public int Skill;
    public int Res;

    public int Spd;
    public int Con;
    public int Aid;

    public int HPGrw;
    public int LuckGrw;
    public int StrGrw;
    public int DefGrw;
    public int SkillGrw;
    public int ResGrw;

    public int SwordExp;
    public int AxeExp;
    public int LanceExp;
    public int BowExp;

    public int DarkExp;
    public int LightExp;
    public int AnimaExp;
    public int StaffExp;

    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    public GameObject item_4;
    public GameObject item_5;

    private bool isDead;
    private bool hasActed;

    public static char WeaponRank(int WExp)
    {
        if (WExp >= 1 && WExp < 31)
            return 'E';
        else if (WExp >= 31 && WExp < 71)
            return 'D';
        else if (WExp >= 71 && WExp < 121)
            return 'C';
        else if (WExp >= 121 && WExp < 181)
            return 'B';
        else if (WExp >= 181 && WExp < 251)
            return 'A';
        else if (WExp >= 251)
            return 'S';
        else
            return '-';


    
    }

    private static int TileCost(GameObject tile)
    {
        if (tile.tag == "Plain")
            return 1;
        else if (tile.tag == "River")
            return int.MaxValue;
        else if (tile.tag == "Cliff")
            return int.MaxValue;
 
        else
            return 1;

    }

    public void Damage(int dmg)
    {
        HP = HP - dmg;
        if (HP <= 0)
            isDead = true;
    }

    public void Attack(GameObject unit)
    {
        if (unit.layer != 9)
        {
            Debug.Log("thats no unit...");
        }
        else
        {
            unit.GetComponent<Unit>().Damage(1);
        }
    }

    public bool IsDead()
    {
        return isDead;      
    }

    public bool HasActed()
    {
        return hasActed;
    }

    public void EndAction()
    {
        hasActed = true;
    }

    public void Refresh()
    {
        hasActed = false;
    }
        

    public List<GameObject> ReachableTiles()
    {
        return TilesReachableFrom(currentTile, Spd);
    }

    private List<GameObject> TilesReachableFrom(GameObject tile, int movement)
    {
        if (tile.layer != 8)
            return null;
        else
        {
            List<GameObject> output = new List<GameObject>();
            output.Add(tile);
            if (Adjacency.TileUp(tile) != null && movement >= TileCost(Adjacency.TileUp(tile)))
            {
                output.AddRange(TilesReachableFrom(Adjacency.TileUp(tile), movement- TileCost(Adjacency.TileUp(tile))));
            }
            if (Adjacency.TileDown(tile) != null && movement >= TileCost(Adjacency.TileDown(tile)))
            {
                output.AddRange(TilesReachableFrom(Adjacency.TileDown(tile), movement - TileCost(Adjacency.TileDown(tile))));
            }
            if (Adjacency.TileLeft(tile) != null && movement >= TileCost(Adjacency.TileLeft(tile)))
            {
                output.AddRange(TilesReachableFrom(Adjacency.TileLeft(tile), movement - TileCost(Adjacency.TileLeft(tile))));
            }
            if (Adjacency.TileRight(tile) != null && movement >= TileCost(Adjacency.TileRight(tile)))
            {
                output.AddRange(TilesReachableFrom(Adjacency.TileRight(tile), movement - TileCost(Adjacency.TileRight(tile))));
            }
            return output;
        }
    }


    private void Update()
    {
        currentTile = Adjacency.TileOf(gameObject);
        if (HasActed())
        {
            GetComponent<SpriteRenderer>().material.color = Color.grey;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }


}

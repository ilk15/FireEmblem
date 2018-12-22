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

    public List<GameObject> reachable()
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(currentTile);
        list.AddRange(reachableFrom(currentTile, Spd));
        return list;

    }

    private List<GameObject> reachableFrom(GameObject tile, int movement)
    {
        List<GameObject> list = new List<GameObject>();
        foreach(GameObject loc in tile.neighbors())
        {
            if (movement > 0)
            {
                list.Add(loc);
                list.AddRange(reachableFrom(loc, movement -1));
            }
            else return null;
        }
        return list;
    }

}

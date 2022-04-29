using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPackage //This class is passed as a parameter to the load level function to specify the data of the level
{
    public LevelPackage(int LevelId, Character[] enemies)
    {
        this.LevelId = LevelId;
        this.enemies = enemies;
    }
    public int LevelId;
    public Character[] friendly = new Character[3];
    public Character[] enemies = new Character[3];
}

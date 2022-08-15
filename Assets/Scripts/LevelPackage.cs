using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPackage
{
    public LevelPackage(Character[] friendly, Character[] enemies)
    {
        this.friendly = friendly;
        this.enemies = enemies;
    }
    public Character[] friendly;
    public Character[] enemies;
}

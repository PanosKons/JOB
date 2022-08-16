using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPackage
{
    public LevelPackage(Character[] friendly, Character[] enemies, DataManager.BackroundId backroundId)
    {
        this.friendly = friendly;
        this.enemies = enemies;
        this.backroundId = backroundId;
    }
    public Character[] friendly;
    public Character[] enemies;
    public DataManager.BackroundId backroundId;
}

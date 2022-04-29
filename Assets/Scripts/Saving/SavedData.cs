using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData //This is a template which specifies which items are saved
{
    public int level;
    public int coins;
    public int gems;
    public void Init()
    {
        level = DataManager.UnlockedLevel;
        coins = DataManager.Coins;
        gems = DataManager.Gems;
    }
}

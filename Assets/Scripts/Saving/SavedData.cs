using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData //This is a template which specifies which items are saved
{
    public int level;
    public int coins;
    public int gems;
    public int[] StoredItemIds;
    public int[] StoredCounts;
    public int[] ItemIds;
    public int[] ItemCounts;
    public void Init()
    {
        level = DataManager.UnlockedLevel;
        coins = DataManager.Coins;
        gems = DataManager.Gems;
        StoredItemIds = new int[16];
        StoredCounts = new int[16];
        ItemIds = new int[7];
        ItemCounts = new int[7];

        for (int i = 0; i < DataManager.StoredInventory.Length; i++)
        {
            StoredItemIds[i] = (int)DataManager.StoredInventory[i].itemId;
            StoredCounts[i] = DataManager.StoredInventory[i].Count;
        }
        for (int i = 0; i < DataManager.Inventory.Length; i++)
        {
            ItemIds[i] = (int)DataManager.Inventory[i].itemId;
            ItemCounts[i] = DataManager.Inventory[i].Count;
        }
    }
}

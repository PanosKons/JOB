using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Burst.Intrinsics;

[System.Serializable]
public struct LevelData
{
    public DataManager.EntityId[] Enemies;
    public DataManager.BackroundId BackroundId;
};
public struct ItemStack : IComparable<ItemStack>
{
    public ItemStack(DataManager.ItemId itemId, int Count)
    {
        this.itemId = itemId;
        this.Count = Count;
    }
    public int CompareTo(ItemStack that)
    {
        if (itemId > that.itemId) return -1;
        if (itemId == that.itemId) return 0;
        return 1;
    }
    public DataManager.ItemId itemId;
    public int Count;
};
public class GlobalManager : MonoBehaviour
{
    public LevelData[] levelDatas;
    public Sprite[] ItemSprites;
    public Dictionary<DataManager.EntityId, Unit> units = new Dictionary<DataManager.EntityId, Unit>
    {
        {DataManager.EntityId.None, new Unit(1,1,0) },
        {DataManager.EntityId.Dorien, new Unit(55,55,11) },
        {DataManager.EntityId.Rena, new Unit(40,40, 8) },
        {DataManager.EntityId.Mikel, new Unit(45,45,13) },
        {DataManager.EntityId.WildPig, new Unit(25,25,6) },
        {DataManager.EntityId.Snake, new Unit(22,22,9) },
        {DataManager.EntityId.MysteriousBandit, new Unit(60,60,12) },
        {DataManager.EntityId.Connor, new Unit(80,80,14) },
        {DataManager.EntityId.PigClone, new Unit(20,20,4) },
        {DataManager.EntityId.Centipede, new Unit(32,32,9) },
        {DataManager.EntityId.Dragon, new Unit(30,30,14) },
        {DataManager.EntityId.CrystalizedDragon, new Unit(40,40,16) },
        {DataManager.EntityId.Adit, new Unit(150,150,23) },
    };

    [HideInInspector]
    public static GlobalManager Instance;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            SaveSystem.LoadData();
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }
    public void DEBUG_RESET()
    {
        if(DataManager.UnlockedLevel == 0)
        {
            DataManager.UnlockedLevel = 100;
            DataManager.Coins = 5000;
            DataManager.Gems = 1000;
            DataManager.StoredInventory = new ItemStack[16];
            DataManager.StoredInventory[0] = new ItemStack(DataManager.ItemId.Potato, 24);
            DataManager.StoredInventory[1] = new ItemStack(DataManager.ItemId.Tomato, 13);
            DataManager.StoredInventory[2] = new ItemStack(DataManager.ItemId.Lettuce, 12);
            DataManager.StoredInventory[3] = new ItemStack(DataManager.ItemId.Carrot, 45);
        }
        else
        {
            DataManager.UnlockedLevel = 0;
            DataManager.Coins = 50;
            DataManager.Gems = 10;
            DataManager.StoredInventory = new ItemStack[16];
            DataManager.Inventory = new ItemStack[7];
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSelectorScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnApplicationQuit()
    {
        SaveSystem.SaveData();
    }
    public void OnLevelPress(int level)
    {
        if (level <= DataManager.UnlockedLevel)
        {
            DataManager.SelectedLevel = level;
            CharacterSelector.Instance.gameObject.SetActive(true);
        }
    }
    public void OpenInventory()
    {
        InventoryManager.Instance.gameObject.SetActive(true);
        InventoryManager.Instance.RefreshInventory();
    }
    public void StartLevel(int level)
    {
        DataManager.SelectedLevel = level;
        Character[] enemies = new Character[3];
        for (int i = 0; i < levelDatas[DataManager.SelectedLevel].Enemies.Length; i++)
        {
            enemies[i] = new Character(units[levelDatas[DataManager.SelectedLevel].Enemies[i]], levelDatas[DataManager.SelectedLevel].Enemies[i]);
        }
        Character[] characters = new Character[3];
        for (int i = 0; i < 3; i++)
        {
            characters[i] = new Character(units[(DataManager.EntityId)(DataManager.CharacterSelectorData[i])], (DataManager.EntityId)(DataManager.CharacterSelectorData[i]));
        }
        DataManager.CurrentLevelPackage = new LevelPackage(characters, enemies, levelDatas[DataManager.SelectedLevel].BackroundId);
        LoadGameScene();
    }
    private void SortInventory(ItemStack[] Inventory)
    {
        Array.Sort(Inventory);
    }
    public bool AddToInventory(ItemStack[] Inventory, ItemStack newStack)
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i].itemId == newStack.itemId)
            {
                Inventory[i].Count += newStack.Count;
                return true;
            }
            else if (Inventory[i].itemId == DataManager.ItemId.None)
            {
                Inventory[i] = newStack;
                SortInventory(Inventory);
                return true;
            }
        }
        return false;
    }
    public void RemoveFromInventory(ItemStack[] Inventory,int index)
    {
        Inventory[index].itemId = DataManager.ItemId.None;
        Inventory[index].Count = 0;
        SortInventory(Inventory);
    }
}

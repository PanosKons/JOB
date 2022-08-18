using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public StoredInventorySlot[] InventorySlots;
    public StoredInventorySlot[] InventorySlotsNormal;
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    public void RefreshInventory()
    {
        foreach (StoredInventorySlot slot in InventorySlots)
            slot.gameObject.SetActive(false);
        for (int i = 0; i < DataManager.StoredInventory.Length; i++)
        {
            if (DataManager.StoredInventory[i].itemId != DataManager.ItemId.None)
            {
                InventorySlots[i].gameObject.SetActive(true);
                InventorySlots[i].itemStack = DataManager.StoredInventory[i];
            }
            InventorySlots[i].NewData();
        }
        for (int i = 0; i < DataManager.Inventory.Length; i++)
        {
            InventorySlotsNormal[i].itemStack = DataManager.Inventory[i];
            InventorySlotsNormal[i].NewData();
        }
    }
    public void MoveItemToInventory(int index)
    {
        if (DataManager.StoredInventory[index].itemId != DataManager.ItemId.None)
        {
            bool moved = GlobalManager.Instance.AddToInventory(DataManager.Inventory, DataManager.StoredInventory[index]);
            if (moved)
            {
                GlobalManager.Instance.RemoveFromInventory(DataManager.StoredInventory, index);
                RefreshInventory();
            }
        }
    }
    public void MoveItemFromInventory(int index)
    {
        if (DataManager.Inventory[index].itemId != DataManager.ItemId.None)
        {
            bool moved = GlobalManager.Instance.AddToInventory(DataManager.StoredInventory, DataManager.Inventory[index]);
            if (moved)
            {
                GlobalManager.Instance.RemoveFromInventory(DataManager.Inventory, index);
                RefreshInventory();
            }
        }
    }
}

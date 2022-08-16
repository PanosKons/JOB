using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public StoredInventorySlot[] InventorySlots;
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
        foreach(ItemStack stack in DataManager.StoredInventory)
        {

        }
    }
}

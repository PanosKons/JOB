using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
}

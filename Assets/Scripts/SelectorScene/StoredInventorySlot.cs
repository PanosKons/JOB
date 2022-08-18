using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoredInventorySlot : MonoBehaviour
{
    public bool countOnly;
    public Image icon;
    public TMPro.TextMeshProUGUI text;
    public ItemStack itemStack;
    public void NewData()
    {
        if(itemStack.itemId == DataManager.ItemId.None || itemStack.Count == 0)
        {
            icon.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
        else
        {
            icon.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            icon.sprite = GlobalManager.Instance.ItemSprites[(int)itemStack.itemId];
            if(countOnly == true)
            {
                text.text = itemStack.Count.ToString();
            }
            else
            {

            text.text = itemStack.itemId.ToString() + "\n" + itemStack.Count;
            }
        }
    }
}

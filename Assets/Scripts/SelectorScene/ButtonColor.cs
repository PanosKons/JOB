using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public Sprite green;
    public int level;
    private void Start()
    {
        if (level < DataManager.UnlockedLevel)
            GetComponent<Image>().sprite = green;
        GetComponent<Button>().onClick.AddListener(delegate { GlobalManager.Instance.OnLevelPress(level); });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = DataManager.Coins.ToString();
    }
}

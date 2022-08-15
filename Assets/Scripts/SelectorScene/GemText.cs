using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = DataManager.Gems.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveData();
    }
}

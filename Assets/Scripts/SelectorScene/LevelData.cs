using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance;
    public LevelDataObj[] levels;
    private void Start()
    {
        Instance = this;
    }
}

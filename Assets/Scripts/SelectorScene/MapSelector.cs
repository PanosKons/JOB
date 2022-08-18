using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    public Button Left;
    public Button Right;
    public int MapIndex;
    public GameObject[] Maps;
    void Update()
    {
        if (MapIndex == 0) Left.gameObject.SetActive(false);
        else Left.gameObject.SetActive(true);
        if (DataManager.UnlockedLevel <= 9)
        {
            Right.gameObject.SetActive(false);
        }
        else if (DataManager.UnlockedLevel <= 20)
        {
            if(MapIndex == 1) Right.gameObject.SetActive(false);
            else Right.gameObject.SetActive(true);
        }
        else
        {
            if(MapIndex == 2) Right.gameObject.SetActive(false);
            else Right.gameObject.SetActive(true);
        }
    }
    public void NextMap()
    {
        Maps[MapIndex].SetActive(false);
        MapIndex++;
        Maps[MapIndex].SetActive(true);
    }
    public void PreviousMap()
    {
        Maps[MapIndex].SetActive(false);
        MapIndex--;
        Maps[MapIndex].SetActive(true);
    }
}

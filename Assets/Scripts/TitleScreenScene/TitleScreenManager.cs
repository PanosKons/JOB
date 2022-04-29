using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    private void Start()
    {
        SaveSystem.LoadData();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void DEBUG_RESET()
    {
        DataManager.UnlockedLevel = 0;
        DataManager.Coins = 50;
        DataManager.Gems = 10;
    }
}

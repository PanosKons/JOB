using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public struct LevelData
{
    public DataManager.EntityId[] Enemies;
};
public class GlobalManager : MonoBehaviour
{
    public LevelData[] levelDatas;

    [HideInInspector]
    public static GlobalManager Instance;
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
        SaveSystem.LoadData();
        DontDestroyOnLoad(this);
    }
    public void DEBUG_RESET()
    {
        DataManager.UnlockedLevel = 0;
        DataManager.Coins = 50;
        DataManager.Gems = 10;
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSelectorScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnApplicationQuit()
    {
        SaveSystem.SaveData();
    }
    public void OnLevelPress(int level)
    {
        if (level <= DataManager.UnlockedLevel)
        {
            DataManager.SelectedLevel = level;
            CharacterSelector.Instance.gameObject.SetActive(true);
        }
    }
    public void StartLevel()
    {
        Character[] enemies = new Character[3];
        for (int i = 0; i < levelDatas[DataManager.SelectedLevel].Enemies.Length; i++)
        {
            enemies[i] = new Character(10, 10, 4, levelDatas[DataManager.SelectedLevel].Enemies[i]);
        }
        Character[] characters = new Character[3];
        for (int i = 0; i < 3; i++)
        {
            characters[i] = new Character(10, 10, 4, (DataManager.EntityId)(DataManager.CharacterSelectorData[i]));
        }
        DataManager.CurrentLevelPackage = new LevelPackage(characters, enemies);
        LoadGameScene();
    }
}

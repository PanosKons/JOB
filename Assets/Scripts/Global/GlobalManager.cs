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
    public Dictionary<DataManager.EntityId, Unit> units = new Dictionary<DataManager.EntityId, Unit>
    {
        {DataManager.EntityId.None, new Unit(1,1,0) },
        {DataManager.EntityId.Dorien, new Unit(55,55,11) },
        {DataManager.EntityId.Rena, new Unit(40,40, 8) },
        {DataManager.EntityId.Mikel, new Unit(45,45,13) },
        {DataManager.EntityId.WildPig, new Unit(25,25,6) },
        {DataManager.EntityId.Snake, new Unit(22,22,9) },
        {DataManager.EntityId.MysteriousBandit, new Unit(60,60,12) },
        {DataManager.EntityId.Connor, new Unit(80,80,14) },
        {DataManager.EntityId.PigClone, new Unit(20,20,4) },
        {DataManager.EntityId.Centipede, new Unit(32,32,9) },
        {DataManager.EntityId.Dragon, new Unit(30,30,14) },
        {DataManager.EntityId.CrystalizedDragon, new Unit(40,40,16) },
        {DataManager.EntityId.Adit, new Unit(150,150,23) },
    };

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
    public void OpenInventory()
    {
        InventoryManager.Instance.gameObject.SetActive(true);
    }
    public void StartLevel(int level)
    {
        DataManager.SelectedLevel = level;
        Character[] enemies = new Character[3];
        for (int i = 0; i < levelDatas[DataManager.SelectedLevel].Enemies.Length; i++)
        {
            enemies[i] = new Character(units[levelDatas[DataManager.SelectedLevel].Enemies[i]], levelDatas[DataManager.SelectedLevel].Enemies[i]);
        }
        Character[] characters = new Character[3];
        for (int i = 0; i < 3; i++)
        {
            characters[i] = new Character(units[(DataManager.EntityId)(DataManager.CharacterSelectorData[i])], (DataManager.EntityId)(DataManager.CharacterSelectorData[i]));
        }
        DataManager.CurrentLevelPackage = new LevelPackage(characters, enemies);
        LoadGameScene();
    }
}

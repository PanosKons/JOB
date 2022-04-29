using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectorUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coins;
    public TMPro.TextMeshProUGUI gems;
    public GameObject CharacterSelector;
    public Image[] CharacterSprites;
    public Sprite[] CharacterFaces;
    int[] indexes = new int[3];
    void Start()
    {
        coins.text = DataManager.Coins.ToString();
        gems.text = DataManager.Gems.ToString();
    }
    public void OnLevelPress(int level)
    {
        if (level <= DataManager.UnlockedLevel)
        {
            Character[] enemies = new Character[3];
            for (int i = 0; i < LevelData.Instance.levels[level].id_of_enemies.Length; i++)
            {
                enemies[i] = new Character(10, 10, 4, LevelData.Instance.levels[level].id_of_enemies[i]);
            }
            DataManager.CurrentLevelPackage = new LevelPackage(level, enemies);
            CharacterSelector.SetActive(true);
        }
    }
    public void Cancel()
    {
        CharacterSelector.SetActive(false);
    }
    public void StartLevel()
    {
        Character[] characters = new Character[3];
        for (int i = 0; i < 3; i++)
        {
            characters[i] = new Character(10, 10, 4, GetId(indexes[i]));
        }
        DataManager.CurrentLevelPackage.friendly = characters;
        SelectorManager.instance.LoadLevel();
    }
    DataManager.EntityId GetId(int index)
    {
        switch(index)
        {
            case 0: return DataManager.EntityId.None;
            case 1: return DataManager.EntityId.Dorien;
            case 2: return DataManager.EntityId.Rena;
            case 3: return DataManager.EntityId.Mikel;
        }
        throw new System.Exception();
    }
    public void CharacterButton(int position)
    {
        int a1 = -1;
        int a2 = -1;
        if(position == 0)
        {
            a1 = 1;
            a2 = 2;
        }
        if (position == 1)
        {
            a1 = 0;
            a2 = 2;
        }
        if (position == 2)
        {
            a1 = 1;
            a2 = 0;
        }
        do
        {
            Increment(position);
        }while (indexes[position] > 0 && (indexes[position] == indexes[a1]|| indexes[position] == indexes[a2]));
    }
    void Increment(int position)
    {
        if (indexes[position] >= 3)
        {
            indexes[position] = 0;
            CharacterSprites[position].enabled = false;
        }
        else
        {
            CharacterSprites[position].sprite = CharacterFaces[indexes[position]];
            indexes[position]++;
            CharacterSprites[position].enabled = true;
        }
    }
}

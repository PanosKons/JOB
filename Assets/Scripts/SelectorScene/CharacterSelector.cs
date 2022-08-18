using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector Instance;
    public Image[] CharacterSprites;
    public Sprite[] CharacterFaces;
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CharacterButton(0);
        CharacterButton(0);
        CharacterButton(0);
        CharacterButton(0);
        CharacterButton(1);
        CharacterButton(1);
        CharacterButton(1);
        CharacterButton(1);
        CharacterButton(2);
        CharacterButton(2);
        CharacterButton(2);
        CharacterButton(2);
    }
    public void CharacterButton(int position)
    {
        int a1 = -1;
        int a2 = -1;
        if (position == 0)
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
            if (DataManager.CharacterSelectorData[position] >= 3)
            {
                DataManager.CharacterSelectorData[position] = 0;
                CharacterSprites[position].enabled = false;
            }
            else
            {
                CharacterSprites[position].sprite = CharacterFaces[DataManager.CharacterSelectorData[position]];
                DataManager.CharacterSelectorData[position]++;
                CharacterSprites[position].enabled = true;
            }
        } while (DataManager.CharacterSelectorData[position] > 0 && (DataManager.CharacterSelectorData[position] == DataManager.CharacterSelectorData[a1] || DataManager.CharacterSelectorData[position] == DataManager.CharacterSelectorData[a2]));
    }
}

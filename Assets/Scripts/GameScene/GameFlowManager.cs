using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFlowManager : MonoBehaviour
{
    public GameObject[] VEntityPrefab; //List of character prefabs
    public static GameFlowManager instance; //Instance
    public GameObject WonScreen;
    public GameObject LostScreen;
    public TMPro.TextMeshProUGUI Coins;
    //List of HEntities
    public Entity[] Entities = new Entity[6];
    public bool ActionInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        int index = 0;
        foreach (Character character in DataManager.CurrentLevelPackage.friendly) //Create all friendly creatures
        {
            if (character.Id != DataManager.EntityId.None)
            {
                Entity entity = Instantiate(VEntityPrefab[(int)character.Id],new Vector3(DataManager.CharacterPositions[index].x+ VEntityPrefab[(int)character.Id].transform.position.x, DataManager.CharacterPositions[index].y + VEntityPrefab[(int)character.Id].transform.position.y, 0.0f),Quaternion.identity).GetComponent<Entity>();
                entity.Init(index, character);
                Entities[index] = entity;
            }
            index++;
        }
        index = 3;
        foreach (Character character in DataManager.CurrentLevelPackage.enemies) //Create all enemy creatures
        {
            if (character.Id != DataManager.EntityId.None)
            {
                Entity entity = Instantiate(VEntityPrefab[(int)character.Id], new Vector3(DataManager.CharacterPositions[index].x + VEntityPrefab[(int)character.Id].transform.position.x, DataManager.CharacterPositions[index].y + VEntityPrefab[(int)character.Id].transform.position.y, 0.0f), Quaternion.identity).GetComponent<Entity>();
                entity.Init(index, character);
                Entities[index] = entity;
            }
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            InputListener.instance.OnLeftClickDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(InputListener.instance.OnLeftClickUp());
        }
    }
    public IEnumerator EnemiesTurn()
    {
        foreach (Entity entity in Entities)
        {
            if (entity != null)
            {
                if (entity.index <= 2)
                {
                    entity.CanAttack = true;
                }
            }
        }
        foreach (Entity entity in Entities)
        {
            if (entity != null)
            {
                if (entity.index >= 3)
                {
                    yield return new WaitForSeconds(1.0f);
                    int secondIndex;
                    do
                    {
                        secondIndex = Random.Range(0, 3);
                    }
                    while (Entities[secondIndex] == null);
                    if (entity.character.Id == DataManager.EntityId.MerakMage || (Random.Range(0,2) == 1 &&( entity.character.Id == DataManager.EntityId.Connor|| entity.character.Id == DataManager.EntityId.CrystalizedDragon)))
                    {
                        yield return StartCoroutine(Entities[entity.index].Action(entity.index));
                    }
                    else
                    {
                        yield return StartCoroutine(Entities[entity.index].Attack());
                        Entities[secondIndex].CalculateDamage(entity.index);
                        Entities[entity.index].CanAttack = false;
                        if (instance.Entities[secondIndex].character.unit.Health <= 0)
                        {
                            yield return StartCoroutine(Entities[secondIndex].EntityDied());
                            Entities[secondIndex].CalculateDeath();
                            break;
                        }
                        else
                        {
                            yield return StartCoroutine(Entities[secondIndex].TakeDamage());
                        }
                    }
                }
            }
        }
    }
    public void CheckIfGameEnded()
    {
        if(Entities[0] == null && Entities[1] == null && Entities[2] == null)
        {
            ActionInProgress = true;
            LostScreen.SetActive(true);
        }
        if(Entities[3] == null && Entities[4] == null && Entities[5] == null)
        {
            ActionInProgress = true;
            WonScreen.SetActive(true);
            int coins = Random.Range(6, 12);
            DataManager.Coins += coins;
            DataManager.UnlockedLevel++;
            SaveSystem.SaveData();
            Coins.text = coins.ToString();
        }
    }
}

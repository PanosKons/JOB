using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    Vector2 clickedPos;
    public static InputListener instance;
    private void Start()
    {
        instance = this;
    }
    public void OnLeftClickDown()
    {
        clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public IEnumerator OnLeftClickUp()
    {
        if (GameFlowManager.instance.ActionInProgress == false)
        {
            GameFlowManager.instance.ActionInProgress = true;
            Vector2 unclickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int firstIndex = -1;
            int secondIndex = -1;
            for (int i = 0; i < DataManager.CharacterPositions.Length; i++)
            {
                if (Vector2.Distance(clickedPos, DataManager.CharacterPositions[i]) < 2.0f)
                {
                    firstIndex = i;
                }
                if (Vector2.Distance(unclickedPos, DataManager.CharacterPositions[i]) < 2.0f)
                {
                    secondIndex = i;
                }
            }
            if (!(firstIndex == -1 || secondIndex == -1))
            {
                if (GameFlowManager.instance.Entities[firstIndex] != null && GameFlowManager.instance.Entities[secondIndex] != null)
                {
                    if (firstIndex <= 2)
                    {
                        if (GameFlowManager.instance.Entities[firstIndex].CanAttack)
                        {
                            if (secondIndex >= 3)
                            {
                            
                                    yield return StartCoroutine(GameFlowManager.instance.Entities[firstIndex].Attack());
                                    GameFlowManager.instance.Entities[secondIndex].CalculateDamage(firstIndex);
                                    GameFlowManager.instance.Entities[firstIndex].CanAttack = false;
                                    if (GameFlowManager.instance.Entities[secondIndex].character.unit.Health <= 0)
                                    {
                                        yield return StartCoroutine(GameFlowManager.instance.Entities[secondIndex].EntityDied());
                                        GameFlowManager.instance.Entities[secondIndex].CalculateDeath();
                                    }
                                    else
                                    {
                                        yield return StartCoroutine(GameFlowManager.instance.Entities[secondIndex].TakeDamage());
                                    }

                            }
                            if (secondIndex <= 2)
                            {
                                yield return StartCoroutine(GameFlowManager.instance.Entities[firstIndex].Action(secondIndex));
                                GameFlowManager.instance.Entities[firstIndex].CanAttack = false;
                            }
                        }
                    }
                }
            }
            bool endTurn = true;
            foreach (Entity entity in GameFlowManager.instance.Entities)
            {
                if (entity != null)
                    if (entity.index <= 2)
                        if (entity.CanAttack)
                        {
                            endTurn = false;
                        }
            }
            if (endTurn) StartCoroutine(GameFlowManager.instance.EnemiesTurn());
            GameFlowManager.instance.ActionInProgress = false;
        }
    }
}

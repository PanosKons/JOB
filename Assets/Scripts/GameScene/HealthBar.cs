using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Entity entity;
    public GameObject green;
    public GameObject red;
    float max;
    float maxHealth;
    private void Start()
    {
        max = green.transform.localScale.x;
        maxHealth = entity.character.unit.MaxHealth;
    }
    private void Update()
    {
        if(entity.character.unit.Health <=0)
        {
            green.SetActive(false);
            red.SetActive(false);
        }
        else
        {
            float point = entity.character.unit.Health * (max / maxHealth);
            green.transform.localScale = new Vector2(point,green.transform.localScale.y);
            green.transform.localPosition = new Vector2((point/200)-max/200,green.transform.localPosition.y);
        }
    }
}

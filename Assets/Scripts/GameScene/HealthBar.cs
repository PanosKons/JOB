using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Entity entity;
    public GameObject green;
    public GameObject red;
    public GameObject Overlay;
    public bool opposite;
    float max;
    float maxHealth;
    private void Start()
    {
        entity = GetComponentInParent<Entity>();
        max = green.transform.localScale.x;
        maxHealth = entity.character.unit.MaxHealth;
    }
    private void Update()
    {
        if(entity.character.unit.Health <=0)
        {
            green.SetActive(false);
            red.SetActive(false);
            Overlay.SetActive(false);
        }
        else
        {
            int mt;
            if (opposite == true) mt = -1; else mt = 1;
            float point = entity.character.unit.Health * (max / maxHealth);
            green.transform.localScale = new Vector2(point,green.transform.localScale.y);
            green.transform.localPosition = new Vector2((point/200 * mt) - (max/200 * mt),green.transform.localPosition.y);
        }
    }
}

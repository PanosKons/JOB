using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIndicator : MonoBehaviour
{
    private Light2D pointLight;
    private Entity parent;
    private void Start()
    {
        pointLight = GetComponent<Light2D>();
        parent = GetComponentInParent<Entity>();
    }
    private int tick = 0;
    private bool ascending = true;
    private void FixedUpdate()
    {
        if(parent.CanAttack == true)
        {
            if(ascending == true)
            {
                tick++;
                if (tick == 50)
                {
                    ascending = false;
                }
            }
            else
            {
                tick--;
                if(tick == 0)
                {
                    ascending = true;
                }
            }
            pointLight.intensity = tick / 50.0f;
        }
        else
        {
            pointLight.intensity = 0;
        }
    }
}

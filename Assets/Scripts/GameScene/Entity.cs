using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Entity : MonoBehaviour
{
    public int index;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    public Character character;
    public bool CanAttack;
    public TextMeshProUGUI text;
    public enum Effects
    {
        Shield,Crystal,Laser,Sting,MageAttack
    };
    public int[] effects;
    public void Init(int index, Character character)
    {
        CanAttack = true;
        this.index = index;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = index;
        this.character = character;
        animator = GetComponent<Animator>();
    }
    public void CalculateDeath()
    {
        GameFlowManager.instance.Entities[index] = null;
        GameFlowManager.instance.CheckIfGameEnded();
        Destroy(gameObject);
    }
    public void CalculateDamage(int index)
    {
        int amount = GameFlowManager.instance.Entities[index].character.unit.Attack;
        if (effects[(int)Effects.Shield] > 0)
        {
            effects[(int)Effects.Shield]--;
            if (effects[(int)Effects.Shield] == 0)
                animator.SetBool("Action", false);
            amount /= 4;
        }
        if (effects[(int)Effects.MageAttack] > 0)
        {
            effects[(int)Effects.MageAttack]--;
            if (effects[(int)Effects.MageAttack] == 0)
                animator.SetBool("Action", false);
            amount *= 2;
        }
        if (effects[(int)Effects.Crystal] > 0)
        {
            effects[(int)Effects.Crystal]--;
            if (effects[(int)Effects.Crystal] == 0)
                animator.SetBool("Action", false);
            amount *= 2;
        }
        if (GameFlowManager.instance.Entities[index].effects[(int)Effects.Crystal]>0)
        {
            effects[(int)Effects.Crystal]--;
            if (effects[(int)Effects.Crystal] == 0)
                GameFlowManager.instance.Entities[index].animator.SetBool("Action", false);
            amount *= 3;
        }

        character.unit.Health -= amount;
    }
    public IEnumerator EntityDied()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(2.0f);
    }
    public IEnumerator TakeDamage()
    {
        if(text != null) //temp
            text.text = "-10";
        animator.SetTrigger("TakeDamage");
        yield return StartCoroutine(WaitTheAnimation("TakeDamage"));
        if (text != null) // temp
            text.text = "";
    }
    public IEnumerator Attack()
    {
        animator.SetTrigger("Attack");
        yield return StartCoroutine(WaitTheAnimation("Attack"));
    }
    public IEnumerator Action(int target)
    {
        animator.SetBool("Action", true);
        yield return StartCoroutine(WaitTheAnimation("Action"));
        switch (character.Id)
        {
            case DataManager.EntityId.Dorien:
                effects[(int)Effects.Shield] = 4;
                break;
            case DataManager.EntityId.Mikel:
                effects[(int)Effects.Crystal] = 1;
                break;
            case DataManager.EntityId.MerakMage:
                effects[(int)Effects.MageAttack] = 1;
                break;
            case DataManager.EntityId.CrystalizedDragon:
                effects[(int)Effects.Crystal] = 1;
                break;
            case DataManager.EntityId.Connor:
                Character ccharacter = new Character();
                ccharacter.Id = DataManager.EntityId.PigClone;
                ccharacter.unit = new Unit(10,10,4);
                for (int i = 3; i < GameFlowManager.instance.Entities.Length; i++)
                {
                    if (GameFlowManager.instance.Entities[i] == null)
                    {
                        Entity entity = Instantiate(GameFlowManager.instance.VEntityPrefab[(int)ccharacter.Id], new Vector3(DataManager.CharacterPositions[i].x + GameFlowManager.instance.VEntityPrefab[(int)ccharacter.Id].transform.position.x, DataManager.CharacterPositions[i].y+ GameFlowManager.instance.VEntityPrefab[(int)ccharacter.Id].transform.position.y, 0.0f), Quaternion.identity).GetComponent<Entity>();
                        entity.Init(i, ccharacter);
                        GameFlowManager.instance.Entities[i] = entity;
                    }
                }
                break;
            case DataManager.EntityId.Rena:
                GameFlowManager.instance.Entities[target].character.unit.Health = Mathf.Min(GameFlowManager.instance.Entities[target].character.unit.Health+5, GameFlowManager.instance.Entities[target].character.unit.MaxHealth);
                break;
        }
    }
    IEnumerator WaitTheAnimation(string name)
    {
        yield return new WaitForEndOfFrame();
        while (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains(name))
        {
            yield return null;
        }
    }
}

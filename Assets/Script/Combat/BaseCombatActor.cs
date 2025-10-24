using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(StatsComponent))]
[RequireComponent(typeof(ManaComponent))]
public class BaseCombatActor : MonoBehaviour
{
    protected HealthComponent actorHealth;

    protected StatsComponent actorStats;

    protected ManaComponent actorMana;

    protected ActionInfo CharacterAction;

    protected float currTimer;
    protected int turnNum;

    [SerializeField]
    protected string characterName;

    public string CharacterName
    {
        get { return characterName; }
    }

    public bool IsWaitingForAction
    {
        get { return CharacterAction.waitToAttack; }
    }

    public bool IsActionSelected
    {
        get { return CharacterAction.actionSelected; }
    }

    public bool IsActionCompleted
    {
        get { return CharacterAction.succsess; }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actorHealth = GetComponent<HealthComponent>();
        actorStats = GetComponent<StatsComponent>();
        actorMana = GetComponent<ManaComponent>();

        currTimer = 0;
        turnNum = 0;

        CharacterAction = new ActionInfo();

        ResetAction();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterAction.succsess)
        {
            return;
        }

        if (!CharacterAction.waitToAttack)
        {
            WaitForAction();
        }
    }

    public bool IsAlive()
    {
        return actorHealth.IsAlive;
    }

    /// <summary>
    /// count for actor turn and if it's full increase turn count by one
    /// </summary>
    /// <returns>if i can  display the ui</returns>
    public virtual void WaitForAction()
    {
        if(!actorHealth.IsAlive)
        {
            return;
        }

        currTimer += Time.deltaTime;

        //Debug.Log(currTimer + "/" + actorStats.AttackCD);
        if(currTimer >= actorStats.AttackCD)
        {
            currTimer = actorStats.AttackCD;
            CharacterAction.waitToAttack = true;
        }
    }

    public virtual ActionInfo TakeAction()
    {
        return CharacterAction;
    }

    public virtual void ResetAction()
    {
        CharacterAction.succsess = false;
        CharacterAction.actionSelected = false;
        CharacterAction.waitToAttack = false;
    }

    public virtual void ChooseTarget()
    {

    }

    /// <summary>
    /// decrease the character health
    /// </summary>
    /// <param name="damage">how much damage the character takes</param>
    /// <returns>is the character alive</returns>
    public virtual bool TakeDamage(int damage)
    {
        damage = Mathf.Abs(damage);
        actorHealth.UpdateHealth(-damage);

        return actorHealth.IsAlive;
    }
    
    #region actions
    protected virtual void BaseAttack()
    {
        Debug.Log(characterName + "Attack");
    }

    protected virtual void UseItem()
    {
        Debug.Log(characterName + "Item");
    }

    protected virtual void PeculiarAction()
    {
        Debug.Log(characterName + "Action");
    }

    protected virtual void Flee()
    {
        Debug.Log(characterName + "Flee");
    }

    protected virtual void Defend()
    {
        Debug.Log(characterName + "BLock");
    }
#endregion

}
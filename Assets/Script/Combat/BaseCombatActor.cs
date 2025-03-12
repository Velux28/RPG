using UnityEngine;


[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(StatsComponent))]
[RequireComponent(typeof(ManaComponent))]
public class BaseCombatActor : MonoBehaviour
{
    protected HealthComponent actorHealth;

    protected StatsComponent actorStats;

    protected ManaComponent actorMana;

    protected float currTimer;
    protected int turnNum;

    [SerializeField]
    protected string characterName;

    public string CharacterName
    {
        get { return characterName; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actorHealth = GetComponent<HealthComponent>();
        actorStats = GetComponent<StatsComponent>();
        actorMana = GetComponent<ManaComponent>();

        currTimer = 0;
        turnNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsAlive()
    {
        return actorHealth.IsAlive;
    }

    public virtual bool WaitForAction()
    {
        if(!actorHealth.IsAlive)
        {
            return false;
        }

        currTimer += Time.deltaTime;

        if(currTimer >= actorStats.AttackCD)
        {
            turnNum++;
            currTimer = 0;
            return true;
        }
        return false;
    }

    public virtual bool TakeAction()
    {
        return true;
    }

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

}

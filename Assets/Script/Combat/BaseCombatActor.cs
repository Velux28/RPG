using UnityEngine;

public class BaseCombatActor : MonoBehaviour
{
    protected HealthComponent actorHealth;

    protected StatsComponent actorStats;

    protected ManaComponent actorMana;

    protected float currTimer;
    protected int turnNum;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

    public virtual void WaitForAction()
    {
        if(!actorHealth.IsAlive)
        {
            return;
        }

        currTimer += Time.deltaTime;

        if(currTimer >= actorStats.AttackCD)
        {
            turnNum++;
            TakeAction();
            currTimer = 0;
        }

    }

    protected virtual void TakeAction()
    {

    }

    protected virtual void BaseAttack()
    {

    }

    protected virtual void UseItem()
    {

    }

    protected virtual void PeculiarAction()
    {

    }

    protected virtual void Flee()
    {

    }

    protected virtual void Defend()
    {

    }

}

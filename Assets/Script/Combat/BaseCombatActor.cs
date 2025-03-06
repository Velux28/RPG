using UnityEngine;

public class BaseCombatActor : MonoBehaviour, ICombatAction
{
    protected HealthComponent actorHealth;

    protected StatsComponent actorStats;

    protected ManaComponent actorMana;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actorHealth = GetComponent<HealthComponent>();
        actorStats = GetComponent<StatsComponent>();
        actorMana = GetComponent<ManaComponent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void TakeAction()
    {

    }

    void ICombatAction.BaseAttack()
    {

    }

    void ICombatAction.UseItem()
    {

    }

    void ICombatAction.PeculiarAction()
    {

    }

    void ICombatAction.Flee()
    {

    }

    void ICombatAction.Defend()
    {

    }

}

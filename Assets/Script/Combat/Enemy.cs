using UnityEngine;

public class Enemy : BaseCombatActor
{
    [SerializeField]
    private float fleeChance = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override ActionInfo TakeAction()
    {
        //choose target 
        CharacterAction.target = Random.Range(0, 4);

        //choose action
        CharacterAction.actionType = EActionType.Meele;

        //lover the hp higher the chance to flee
        //float flee = fleeChance/actorHealth.HealthPerc;

        //if (flee > Random.RandomRange(0, fleeChance))
        //{

        //}

        CharacterAction.actionSelected = true;  
        CharacterAction.succsess = true;
        CharacterAction.waitToAttack = false;

        return CharacterAction;
    }

    protected override void BaseAttack()
    {
        base.BaseAttack();
        int x = actorStats.Strenght;
    }
    protected override void PeculiarAction()
    {
        base.PeculiarAction();
    }

    protected override void UseItem()
    {
        base.UseItem();
    }

    protected override void Flee()
    {
        base.Flee();
    }

    protected override void Defend()
    {
        base.Defend();
    }
}

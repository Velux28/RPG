using UnityEngine;

public class Enemy : BaseCombatActor
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool TakeAction()
    {
        int i = Random.Range(0, 5);

        switch (i)
        {
            case 0:
                BaseAttack();
                break;
            case 1:
                PeculiarAction();
                break;
            case 2:
                UseItem();
                break;
            case 3:
                Flee();
                break;
            case 4:
                Defend();
                break;
            default:
                BaseAttack();
                break;
        }

        return true;
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

using UnityEngine;

[RequireComponent (typeof(HealthComponent))]
[RequireComponent (typeof(StatsComponent))]
[RequireComponent (typeof(ManaComponent))]
public class Character : BaseCombatActor
{

    private int actionIndex;
    [SerializeField]
    private int maxAction = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool TakeAction()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            actionIndex++;
            actionIndex = actionIndex % maxAction;
            Debug.Log(characterName + actionIndex);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            actionIndex--;
            actionIndex = actionIndex % maxAction;
            Debug.Log(characterName + actionIndex);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (actionIndex)
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
        return false;
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

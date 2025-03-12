using UnityEngine;

public class Character : BaseCombatActor
{
    [SerializeField]
    private string characterName;

    private int actionIndex;
    [SerializeField]
    private int maxAction = 5;

    public string CharacterName
    {
        get { return characterName; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void TakeAction()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            actionIndex = actionIndex + 1 % maxAction;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            actionIndex = actionIndex - 1 % maxAction;
        }

        if(Input.GetKeyDown(KeyCode.Space))
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
        }
    }

    protected override void BaseAttack()
    {

        int x = actorStats.Strenght;
    }
    protected override void PeculiarAction()
    {
        
    }

    protected override void UseItem()
    {
        throw new System.NotImplementedException();
    }

    protected override void Flee()
    {
        throw new System.NotImplementedException();
    }

    protected override void Defend()
    {

    }

}

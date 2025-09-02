using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(HealthComponent))]
[RequireComponent (typeof(StatsComponent))]
[RequireComponent (typeof(ManaComponent))]
public class Character : BaseCombatActor
{

    private int actionIndex;
    private int targetIndex;
    [SerializeField]
    private int maxAction = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionIndex = 0;

        //CharacterAction = new ActionInfo();

        //CharacterAction.actionType.Enqueue(EActionType.None);
        //CharacterAction.target.Enqueue(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override ActionInfo TakeAction()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CharacterAction.actionType == EActionType.None)
            {
                actionIndex++;
                Debug.Log(characterName + actionIndex);
            }
            //else
            //{
            //    CharacterAction.target++;
            //    Debug.Log(characterName + CharacterAction.target);
            //}
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CharacterAction.actionType == EActionType.None)
            {
                actionIndex--;
                Debug.Log(characterName + actionIndex);
            }
            //else
            //{
            //    CharacterAction.target--;
            //    Debug.Log(characterName + CharacterAction.target);

            //}
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CharacterAction.actionType == EActionType.None)
            {
                actionIndex = maxAction % actionIndex;
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
                }
            }
            else
            {
                CharacterAction.succsess = true;
            }
        }
        return CharacterAction;
    }

    protected override void BaseAttack()
    {
        base.BaseAttack();
        CharacterAction.actionType = EActionType.Meele;
    }
    protected override void PeculiarAction()
    {
        base.PeculiarAction();
        CharacterAction.actionType = EActionType.ClassAction;

    }

    protected override void UseItem()
    {
        base.UseItem();
        CharacterAction.actionType = EActionType.Item;

    }

    protected override void Flee()
    {
        base.Flee();
        CharacterAction.actionType = EActionType.Flee;

    }

    protected override void Defend()
    {
        base.Defend();
        CharacterAction.actionType = EActionType.Defend;

    }

}

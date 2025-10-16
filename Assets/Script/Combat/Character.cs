using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(HealthComponent))]
[RequireComponent (typeof(StatsComponent))]
[RequireComponent (typeof(ManaComponent))]
public class Character : BaseCombatActor
{
    [SerializeField]
    private int maxAction = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterAction.actionType=EActionType.Meele;

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
            if (CharacterAction.actionSelected == false)
            {
                int x = (int)CharacterAction.actionType + 1;
                CharacterAction.actionType = (EActionType)(x % (int)EActionType.Flee);
                Debug.Log(characterName +": "+ CharacterAction.actionType);
            }
            //else
            //{
            //    CharacterAction.target++;
            //    Debug.Log(characterName + CharacterAction.target);
            //}
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CharacterAction.actionSelected == false)
            {
                int x = (int)CharacterAction.actionType - 1;
                CharacterAction.actionType = (EActionType)(x % (int)EActionType.Flee);
                Debug.Log(characterName + ": " + CharacterAction.actionType);
            }
            //else
            //{
            //    CharacterAction.target--;
            //    Debug.Log(characterName + CharacterAction.target);

            //}
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CharacterAction.actionSelected == false)
            {
                CharacterAction.actionSelected = true;
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

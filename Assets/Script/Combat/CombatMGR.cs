
using System.Collections.Generic;
using UnityEngine;


public class CombatMGR : MonoBehaviour
{
    [SerializeField]
    List<BaseCombatActor> playerActors; 
    [SerializeField]
    List<BaseCombatActor> foeActors;

    private Queue<BaseCombatActor> attackQueue;
    private BaseCombatActor currAttacker;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //for filling the lists use a safe file
        attackQueue = new Queue<BaseCombatActor>();
        //playerActors = new List<BaseCombatActor>();
        //foeActors = new List<BaseCombatActor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBattleEnd())
        {
            //player is dead

            return;
        }
        else if (CheckBattleEnd(false))
        {
            //enemy is dead

            return;
        }

        WaitForAction();

        if (attackQueue.Count == 0)
        {
            return;
        }

        //if there's at least one action to consume, remove from queue and wait and assign the curr combat actor
        if (currAttacker == null)
        {
            //attackQueue.Peek().ResetAction();
            //Debug.Log("dequeue " + attackQueue.Peek().CharacterName);
            currAttacker = attackQueue.Dequeue();
        }

        if (currAttacker.IsActionCompleted)
        {
            //remove actor from queue and reset variables
            currAttacker.ResetAction();
            currAttacker = null;
        }
        else if (currAttacker.IsActionSelected)
        {
            ChooseTarget();
        }
        else if(currAttacker.IsWaitingForAction)
        {
            TakeAction();
        }


    }

    void WaitForAction()
    {
        foreach (BaseCombatActor player in playerActors)
        {
            if (player.IsAlive())
            {
                player.WaitForAction();
                if (player.IsWaitingForAction)
                {
                    attackQueue.Enqueue(player);
                }
            }
        }

        foreach (BaseCombatActor foe in foeActors)
        {
            if (foe.IsAlive())
            {
                foe.WaitForAction();
                if (foe.IsWaitingForAction)
                {

                    attackQueue.Enqueue(foe);
                }
            }
        }
    }

    void TakeAction()
    {
        currAttacker.TakeAction();
    }

    void ChooseTarget()
    {
        currAttacker.ChooseTarget();
    }
    void FillPlayerAcor(List<BaseCombatActor> actors)
    {
        playerActors.Clear();

        playerActors.AddRange(actors);
    }


    void FillFoeAcor(List<BaseCombatActor> actors)
    {
        foeActors.Clear();

        foeActors.AddRange(actors);
    }

    bool CheckBattleEnd(bool checkPlayer=true)
    {
        bool partyDead = true;

        if(checkPlayer)
        {
            foreach (BaseCombatActor actor in playerActors)
            {
                if (actor.IsAlive())
                {
                    //if a single member of the foe party is alive the battle is not finish
                    partyDead = false;
                    break;
                }
            }
            return partyDead;
        }


        foreach (BaseCombatActor actor in foeActors)
        {
            if (actor.IsAlive())
            {
                //if a single member of the foe party is alive the battle is not finish
                partyDead = false;
                break;
            }
        }

        return partyDead;
    }

    /// <summary>
    /// function called when there's no more enemy
    /// </summary>
    void BattleFinish()
    {
        Debug.Log("Win");
    }

    /// <summary>
    /// function called when the party is dead
    /// </summary>
    void GameOver()
    {
        Debug.Log("Lost");

    }
}

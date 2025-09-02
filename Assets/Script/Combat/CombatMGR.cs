
using System.Collections.Generic;
using UnityEngine;


public class CombatMGR : MonoBehaviour
{
    [SerializeField]
    List<BaseCombatActor> playerActors; 
    [SerializeField]
    List<BaseCombatActor> foeActors;

    private Queue<BaseCombatActor> attackQueue;


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
        if(CheckBattleEnd())
        {
            //change scene/ play victory cutscene

            return;
        }

        //if there's at least one action to consume, remove from queue and wait
        if (attackQueue.Count > 0 && attackQueue.Peek().TakeAction().succsess == true)   
        {
            attackQueue.Peek().ResetAction();
            //Debug.Log("dequeue " + attackQueue.Peek().CharacterName);
            attackQueue.Dequeue();
        }

        for (int i = 0; i < playerActors.Count; i++)
        {
            if (playerActors[i].IsAlive())
            {
               if(playerActors[i].WaitForAction())
               {
                    attackQueue.Enqueue(playerActors[i]);
               }
            }
        }

        for (int i = 0; i < foeActors.Count; i++)
        {
            if (foeActors[i].IsAlive())
            {
                if(foeActors[i].WaitForAction())
                {
                    
                    attackQueue.Enqueue(foeActors[i]);
                }
            }
        }
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

    bool CheckBattleEnd()
    {
        bool partyDead = true;
        foreach(BaseCombatActor actor in foeActors) 
        {
            if (actor)
            {
                //if a single member of the foe party is alive the battle is not finish
                partyDead = false;
                break;
            }
        }


        if (partyDead)
        {
            //give exp and level up
            BattleFinish();
            return true;
        }

        partyDead = true;

        for (int i = 0; i < playerActors.Count; i++)
        {
            if (playerActors[i].IsAlive())
            {
                //if a single member of the foe party is alive the battle is not finish
                partyDead = false;
                break;
            }
        }

        if (partyDead)
        {
            //ends the battle and restart from save
            GameOver();
            return true;
        }

        return false;
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

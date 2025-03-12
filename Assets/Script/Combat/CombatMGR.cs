
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
        attackQueue = new Queue<BaseCombatActor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckBattleEnd())
        {
            //change scene/ play victory cutscene

        }


        if (attackQueue.Count > 0 && attackQueue.Peek().TakeAction()) 
        {
            Debug.Log("dequeue " + attackQueue.Peek().CharacterName);
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

    bool CheckBattleEnd()
    {
        bool partyDead = true;
        for (int i = 0; i < foeActors.Count; i++)
        {
            if (foeActors[i].IsAlive())
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

    void BattleFinish()
    {
        Debug.Log("Win");
    }

    void GameOver()
    {
        Debug.Log("Lost");

    }
}

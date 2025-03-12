
using System.Collections.Generic;
using UnityEngine;


public class CombatMGR : MonoBehaviour
{
    List<BaseCombatActor> playerActors; 
    List<BaseCombatActor> foeActors;

    float battleTimer = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckBattleEnd())
        {
            //change scene/ play victory cutscene

        }

        for (int i = 0; i < playerActors.Count; i++)
        {
            if (playerActors[i].IsAlive())
            {
                playerActors[i].WaitForAction();
            }
        }

        for (int i = 0; i < foeActors.Count; i++)
        {
            if (foeActors[i].IsAlive())
            {
                foeActors[i].WaitForAction();
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

    }

    void GameOver()
    {

    }
}

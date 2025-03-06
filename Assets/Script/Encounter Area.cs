//using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterArea : MonoBehaviour
{
    [SerializeField]
    private float encounterRate;
    [SerializeField]
    public Dictionary<Enemy, int> encounterTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GenerateEncounter()
    {
        if (encounterRate > Random.Range(0f, 1f))
        {
            return true;
        }
        return false;
    }

    public Enemy GetEnemy()
    {
        int encounter = Random.Range(0, 100);
        int x = 0;


        foreach (KeyValuePair<Enemy,int> enemy in encounterTable)
        {
            x += enemy.Value;
            if (x >= encounter)
            {
                return enemy.Key;
            }
        }
        return null;
    }
}

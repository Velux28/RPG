using UnityEngine;

public class Character : BaseCombatActor, ICombatAction
{
    [SerializeField]
    private string characterName;

    public string CharacterName
    {
        get { return characterName; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ICombatAction.BaseAttack()
    {
        actorStats
    }

    void ICombatAction.UseItem()
    {
        throw new System.NotImplementedException();
    }

    void ICombatAction. PeculiarAction()
    {
        throw new System.NotImplementedException();
    }

    void ICombatAction.Flee()
    {
        throw new System.NotImplementedException();
    }

}

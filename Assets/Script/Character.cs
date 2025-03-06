using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string characterName;

    private HealthComponent characterHealth;

    public string CharacterName
    {
        get { return characterName; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterHealth = GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

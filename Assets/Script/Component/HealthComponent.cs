using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    public int currHealth;

    public bool IsAlive
    {
        get
        {
            return currHealth > 0;
        }

    }

    public float HealthPerc
    {
        get
        {
            return currHealth / maxHealth;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int healthAmount)
    {
        currHealth = Mathf.Clamp(currHealth + healthAmount, 0, maxHealth);
    }

    public void IncreaseMaxHealth(int newMaxhealth)
    {
        currHealth += newMaxhealth - maxHealth;
        maxHealth = newMaxhealth;
    }
}

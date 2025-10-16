using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    public int currHealth;

    /// <summary>
    /// return true if the actor has more then 0 health
    /// </summary>
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

    /// <summary>
    /// Change The value of the health keeping it between 0 and max health
    /// </summary>
    /// <param name="healthAmount">if >0 add and if <0 decrease</param>
    public void UpdateHealth(int healthAmount)
    {
        currHealth = Mathf.Clamp(currHealth + healthAmount, 0, maxHealth);
    }

    /// <summary>
    /// hange the value of max health of the of the actor, the current health increase or decrease by the delta of the health change
    /// </summary>
    /// <param name="newMaxhealth">The new max health, maxHealth = newMaxhealth;</param>
    public void IncreaseMaxHealth(int newMaxhealth)
    {
        currHealth += newMaxhealth - maxHealth;
        maxHealth = newMaxhealth;
    }
}

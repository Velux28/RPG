using UnityEngine;

public class ManaComponent : MonoBehaviour
{
    [SerializeField]
    private int maxMana;
    public int currMana;

    public float ManaPerc
    {
        get
        {
            return currMana / maxMana;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMana(int manaAmount)
    {
        currMana = Mathf.Clamp(currMana + manaAmount, 0, maxMana);
    }

    public void IncreaseMaxHealth(int newMaxmana)
    {
        currMana += newMaxmana - maxMana;
        maxMana = newMaxmana;
    }
}

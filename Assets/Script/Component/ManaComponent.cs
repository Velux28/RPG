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
        currMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Change The value of the mana keeping it between 0 and max mana
    /// </summary>
    /// <param name="manaAmount">if >0 add and if <0 decrease</param>
    public void UpdateMana(int manaAmount)
    {
        currMana = Mathf.Clamp(currMana + manaAmount, 0, maxMana);
    }

    /// <summary>
    /// Change the value of Max mana of the of the actor, the current mana keeps the same proportion
    /// </summary>
    /// <param name="newMaxmana">The new max mana, maxMana = newMaxmana;</param>
    public void ChangeMaxMana(int newMaxmana)
    {
        currMana = currMana*newMaxmana/maxMana;
        maxMana = newMaxmana;
    }
}

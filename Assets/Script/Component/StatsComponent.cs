using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    [SerializeField]
    private int strenght;
    [SerializeField]
    private int dexterity;
    [SerializeField]
    private int magic;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int evasion;
    [SerializeField]
    private int defense;
    [SerializeField]
    private int magicDefense;


    #region Get
    public int Strenght
    {
        get { return strenght; }
    }
    public int Dexterity
    {
        get { return dexterity; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int Evasion
    { 
        get { return evasion; } 
    }
    public int Magic
    {
        get { return magic; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int MagicDefense
    {
        get { return magicDefense; }
    }
    #endregion


    #region IncreaseStats
    public void IncreaseStrenght(int strenghtToAdd)
    {
        strenght = Mathf.Clamp(strenght + strenghtToAdd, 1, 999);
    }
    public void IncreaseDexterity(int dexterityToAdd)
    {
        dexterity = Mathf.Clamp(dexterity + dexterityToAdd, 1, 999);
    }
    public void IncreaseMagic(int magicToAdd)
    {
        magic = Mathf.Clamp(magic + magicToAdd, 1, 999);
    }
    public void IncreaseSpeed(int speedToAdd)
    {
        speed = Mathf.Clamp(speed + speedToAdd, 1, 999);
    }
    public void IncreaseEvasion(int evasionToAdd)
    {
        evasion = Mathf.Clamp(evasion + evasionToAdd, 0, 100);
    }
    public void IncreaseDefense(int defenseToAdd)
    {
        defense = Mathf.Clamp(defense + defenseToAdd, 1, 999);
    }
    public void IncreaseMagicDefense(int magicDefenseToAdd)
    {
        magicDefense = Mathf.Clamp(magicDefense + magicDefenseToAdd, 1, 999);
    }
    #endregion
}

using UnityEngine;

public interface ICombatAction
{
    protected void BaseAttack();

    protected void UseItem();

    protected void PeculiarAction();

    protected void Flee();

    protected void Defend();

}

using System.Collections.Generic;
using UnityEngine;

public class ActionInfo
{
    //public Queue<EActionType> actionType;
    //public Queue<int> target;
    public EActionType actionType;
    public int target;

    public bool waitToAttack = false;
    public bool actionSelected = false;
    public bool succsess = false;
}

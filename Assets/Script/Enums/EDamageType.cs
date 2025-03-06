using System;
using UnityEngine;

[Flags]
public enum EDamageType
{
    Physical = 1,
    Magic = 2,
    Fire = 4,
    Thunder = 8,
    Ice = 16,
    Dark = 32,
    Light = 64,

}

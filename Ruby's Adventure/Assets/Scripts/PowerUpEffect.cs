using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was written by Hector Merced

public abstract class PowerUpEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}

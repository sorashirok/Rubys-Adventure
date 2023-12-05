using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This sript was written by Hector Merced

[CreateAssetMenu(menuName = "Powerups/Buff")]

public class Buff : PowerUpEffect
{
    public float amount;
    public int projectileAmount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<RubyController>().speed += amount;
        target.GetComponent<RubyController>().projectileSpeed += projectileAmount;
    }
}

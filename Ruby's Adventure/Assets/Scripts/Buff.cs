using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Buff")]

public class Buff : PowerUpEffect
{
    public float amount;
    public GameObject newProjectile;
    public override void Apply(GameObject target)
    {
        target.GetComponent<RubyController>().speed += amount;
        target.GetComponent<RubyController>().projectilePrefab = newProjectile;


    }
}

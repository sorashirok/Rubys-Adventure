using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was written by Hector Merced

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerupEffect;
    public AudioClip SFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            Destroy(gameObject);
            powerupEffect.Apply(other.gameObject);

            controller.PlaySound(SFX);
        }
    }
}

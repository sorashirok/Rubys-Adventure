using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 3f; // Adjust the speed as needed

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

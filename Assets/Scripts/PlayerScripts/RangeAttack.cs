using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : WeaponBase
{
    public Actor Owner; 
    public float damageAmount = 25.0f;
    public float movementSpeed = 20f;
    public float lifetime = 2f;
    Collider attackCollider; 
  
    protected Rigidbody rb;

    protected override void ChildStart()
    {
        attackCollider = GetComponent<Collider>();
        rb = gameObject.AddComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * movementSpeed;
        rb.useGravity = false;
        Destroy(gameObject, lifetime);
    }

    protected override void ChildUpdate()
    {
        attackCollider.enabled = true; 
    }

    public override void PerformAttack()
    {
        Debug.Log("Range Attack - Perform Attack!"); 
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        HealthSystem hs = other.GetComponentInParent<HealthSystem>();
        if (hs)
        {
            hs.TakeDamage(damageAmount);
        }
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class RangeAttack : WeaponBase
{
    public float damageAmount = 10.0f;
    public float movementSpeed = 20f;
    public float lifetime = 2f;

    protected Rigidbody rb;

    protected override void ChildStart()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * movementSpeed;
        rb.useGravity = false;
        Destroy(gameObject, lifetime);
    }

    protected override void ChildUpdate()
    {
        
    }



    public override void PerformAttack()
    {
        Debug.Log("Range Attack - Perform Attack!"); 


    }

    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name); 
        Destroy(gameObject);
    }

    /*
    public void OnDeath()
    {
        Destroy(gameObject);
    }
    */
}

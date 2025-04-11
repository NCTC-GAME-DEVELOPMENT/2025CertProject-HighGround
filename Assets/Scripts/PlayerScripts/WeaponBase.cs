using System.Security.Cryptography;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float AttackRetrigerDelay = .25f;
    float AttackRetriggerCounter = 0; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChildStart(); 
    }

    protected virtual void ChildStart()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (AttackRetriggerCounter > 0)
        {
            AttackRetriggerCounter -= Time.deltaTime; 
        }

        ChildUpdate(); 
    }

    protected virtual void ChildUpdate()
    {

    }

    public void OnAttack()
    {
        if (AttackRetriggerCounter > 0)
        {
            // ignore this fire Attack Signal. 
            // We're waiting on weapon to cool down 
            return; 
        }
        PerformAttack(); 
    }

    public virtual void PerformAttack()
    {

    }
}

using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeleeAttack : WeaponBase
{
    public float damageAmount = 50.0f;
    public float attackRange = 2f;
    public GameObject MetalPipe;
    public bool IsTriggerActive = false;
    public MeleeTrigger meleeTrigger; 
    Animator anim; 
    protected override void ChildStart()
    {
        anim  = gameObject.GetComponent<Animator>();
    }

    protected override void ChildUpdate()
    {
        meleeTrigger.gameObject.SetActive(IsTriggerActive); 


    }

    public override void PerformAttack()
    {
       Debug.Log("Melee Attack - Perform Attack!");

        
       anim.SetTrigger("Attack");
    }



}


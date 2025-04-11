using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeleeAttack : WeaponBase
{
    public float attackRange = 2f;

    OnOffTriggerAttack attackOn;
    OnOffTriggerAttack attackOff;
    OnTriggerAttack oa;


    protected override void ChildStart()
    {
       
    }

    protected override void ChildUpdate()
    {

    }

    public override void PerformAttack()
    {
        Debug.Log("Melee Attack - Perform Attack!");

        oa.OnAttack();

    }
}


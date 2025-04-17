using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeleeAttack : WeaponBase
{
    public float attackRange = 2f;
    public GameObject MetalPipe;
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

        Animator anim = MetalPipe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        //oa.OnAttack();

    }
}


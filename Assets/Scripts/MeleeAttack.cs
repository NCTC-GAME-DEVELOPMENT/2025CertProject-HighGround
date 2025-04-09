using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MeleeAttack : WeaponBase
{
    public float damageAmount = 10.0f;
    public float attackRange = 2f;
    float lastAttackTime;

    protected override void ChildStart()
    {
       
    }

    protected override void ChildUpdate()
    {

    }

    public override void PerformAttack()
    {
        Debug.Log("Melee Attack - Perform Attack!");

        //RaycastHit hit;
        //bool hasHit = Physics.Raycast(ProjectileSpawnPoint.transform.position, BarrelEnd.transform.forward, out hit, RaycastDistance);

        //Instantiate(HitMarkerPrefab, hit.point, Quaternion.Euler(hit.normal));

        /*
        RobotPlayerPW cp = hit.collider.gameObject.GetComponentInParent<CombatPlayer>();
        if (cp)
        {
            Destroy(gameObject);

            string KillMessage = gameObject.name + " hit " + cp.gameObject.name;
            Debug.Log(KillMessage);
            return;
        }

        RobotPlayerPW RangeAttack = hit.collider.gameObject.GetComponentInParent<RobotPlayerPW>();
        if (RangeAttack)
        {
            Destroy(RangeAttack.gameObject);
        }
        */
    }
}


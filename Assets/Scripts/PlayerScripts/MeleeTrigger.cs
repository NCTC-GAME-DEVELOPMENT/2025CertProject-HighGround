using UnityEngine;

public class MeleeTrigger : MonoBehaviour
{

    public Actor Owner; 
    public MeleeAttack attack;

    void OnTriggerEnter(Collider other)
    {
        HealthSystem hs = other.GetComponentInParent<HealthSystem>();
        if (hs)
        {
            hs.TakeDamage(Owner, attack.damageAmount);
        }
    }

    public void OnAnimationDone()
    {

    }
}

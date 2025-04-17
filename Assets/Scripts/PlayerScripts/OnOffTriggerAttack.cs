using UnityEngine;

public class OnOffTriggerAttack : MonoBehaviour
{
    public bool attackIsOff;
    public bool attackIsOn;
    WeaponBase delay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackTurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTurnOn()
    {
        attackIsOff = false;
        attackIsOn = true;
    }

    public void AttackTurnOff() 
    {
        attackIsOff = true;
        attackIsOn = false;
    }
}

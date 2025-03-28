using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PWPawn : Pawn
{
    public float StartingHealth = 100.0f;
    public float Health = 100.0f;

    public bool SetupProjectiles = true;
    protected GameObject CurrentProjectile;

    public UnityEvent OnDeath;

    protected void Start()
    {
        if (CurrentProjectile == null)
        {
            SetupProjectiles = false; // might change later...
        }
    }

    public virtual void Horizontal(float value)
    {
        //LOG("PWPawn: Horizontal");
    }

    public virtual void Vertical(float value)
    {
        //LOG("PWPawn: Verticle");
    }

    public virtual void Fire(bool value)
    {
        LOG("PWPawn: Fire");
    }

    public virtual void Swing(bool value)
    {
        LOG("PWPawn: Swing");
    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        //base.ProcessDamage(Source, Value, EventInfo, Instigator);

        Health = Health - Value;
        if (Health <= 0)
        {
            OnDeath?.Invoke();
        }

        return true;
    }

    public virtual void DeathTest()
    {
        IgnoresDamage = true;
        Debug.Log(ActorName + ": was absolutely demolished rip :(");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Info
{
    public bool IsAI = false;
    public bool IsHuman = false;

    /// <summary>
    /// Player Number for Grabbing Input
    /// </summary>
    public int InputPlayerNumber = 0;

    /// <summary>
    /// Player Number in the game
    /// </summary>
    public int PlayerNumber = 0;

    protected Pawn ControlledPawn;

    protected virtual void Start()
    {

    }

    public Pawn GetPawn()
    {
        return ControlledPawn;
    }

    public virtual bool ControlPawn(Pawn p)
    {
        if (!(p.BecomeControlledBy(this)))
        {
            LOG_ERROR("Controler - Possession Failure");
            return false;
        }

        // If we have a Possessed Pawn already, Call Unpossess on it. 
        if (ControlledPawn)
        {
            ControlledPawn.BecomeReleased();
        }

        ControlledPawn = p;
        return true;
    }

    /// <summary>
    /// PossesPawn version taking GameObject with Pawn Script attached to it. 
    /// </summary>
    /// <param name="PawnGameObject">Game Object with Pawn Script Attached to it</param>
    /// <returns></returns>
    public virtual bool ControlPawn(GameObject PawnGameObject)
    {
        Pawn p = PawnGameObject.GetComponent<Pawn>();
        if (!p)
        {
            LOG_ERROR("GameObject " + PawnGameObject.name + " is not a pawn.");
            return false;
        }
        return ControlPawn(p);
    }

    public virtual bool ReleasePawn(Pawn p)
    {
        p.BecomeReleased();

        ControlledPawn = null;
        return true;
    }

    /// <summary>
    /// Spawning, which is entering the game
    /// </summary>
    public virtual void EnterGame()
    {

    }

    /// <summary>
    /// Becoming a spectator
    /// </summary>
    public virtual void BecomeSpectator()
    {

    }
}

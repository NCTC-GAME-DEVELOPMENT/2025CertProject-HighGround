using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerController : PlayerController
{
    public GameObject PlayerPrefabObject;

    // public GameObject SpectatorPawn;

    protected override void Start()
    {
        base.Start();
        BecomeSpectator();
    }


    protected override void ProcessInput()
    {
        if (!ControlledPawn)
        {
            // If we don't have a pawn, don't bother processing input. 
            return;
        }

        if (InputCurrent.buttonNorth)
        {
            Fire(InputCurrent.buttonNorth);
        }

        if (InputCurrent.buttonSouth) 
        {
            Swing(InputCurrent.buttonSouth);
        }

        Vertical(InputCurrent.leftStick.y);
        Horizontal(InputCurrent.rightStick.x);
    }

    public override void Vertical(float value)
    {
        //LOG("PWPC: Vertical");
        PWPawn PWP = ((PWPawn)ControlledPawn);
        if (PWP)
        {
            PWP.Vertical(value);
        }
    }
    public override void Horizontal(float value)
    {
        //LOG("PC: Vertical");
        PWPawn PWP = ((PWPawn)ControlledPawn);
        if (PWP)
        {
            PWP.Horizontal(value);
        }
    }

    public override void Fire(bool value)
    {
        //((PWPawn)PossesedPawn).Fire(value);

        if (value)
        {
            LOG("PC: Fire");
            PWPawn PWP = ((PWPawn)ControlledPawn);
            if (PWP)
            {
                PWP.Fire(value);
            }
        }
    }

    public override void Swing(bool value)
    {
        //((PWPawn)PossesedPawn).Fire1(value);

        if (value)
        {
            LOG("PC: Swing");
            PWPawn PWP = ((PWPawn)ControlledPawn);
            if (PWP)
            {
                PWP.Swing(value);
            }
        }
    }

    /*
    public override void BecomeSpectator()
    {
        if (SpectatorPawn)
        {
            ControlPawn(SpectatorPawn);
        }
    }

    public override void EnterGame()
    {
        SpawnPoint spawnAT = GameManager.self.GetRandomSpawnPoint();
        if (spawnAT == null)
        {
            Debug.LogError("No spawn point from Game Manager");
            return;
        }

        GameObject newPlayerPawn = Factory(PlayerPrefabObject, spawnAT.gameObject.transform.position, spawnAT.gameObject.transform.rotation, this);
        ControlPawn(newPlayerPawn);
    }
    */

    // the code above that is commented might come in use later...

}

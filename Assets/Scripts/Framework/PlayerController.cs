using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    /// <summary>
    /// Show Input for this controler, Super Spammy when true. 
    /// </summary>
    public bool LogInputStateInfo = false;

    protected InputPoller inputPoller;
    protected InputData InputCurrent;

    protected InputData InputPrevious;

    protected override void Start()
    {
        base.Start();
        IsHuman = true;

        inputPoller = InputPoller.Self;
        if (!inputPoller)
        {
            LOG_ERROR("****PLAYER CONTROLER: No Input Poller in Scene");
            return;
        }
    }

    protected void Update()
    {
        InputPrevious = InputCurrent;
        GetInput();
        ProcessInput();
    }

    protected virtual void GetInput()
    {
        if (!inputPoller)
        {
            LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): No Input Poller in Scene");
            return;
        }

        InputCurrent = InputPoller.Self.GetInput(InputPlayerNumber);

        if (LogInputStateInfo)
        {
            LOG(InputCurrent.ToString());
        }

    }

    protected virtual void ProcessInput()
    {

    }

    public virtual void Horizontal(float value) // movement
    {
        if (value != 0)
        {
            LOG("Del-Horizontal (" + value + ")");
        }
    }

    public virtual void Vertical(float value) // movement
    {
        if (value != 0)
        {
            LOG("Del-Vertical (" + value + ")");
        }
    }

    public virtual void Fire(bool value) // projectile weapon
    {
        if (value)
        {
            LOG("Del-Fire");
        }
    }

    public virtual void Swing(bool value) // melee weapon
    {
        if (value)
        {
            LOG("Del-Swing");
        }
    }
}

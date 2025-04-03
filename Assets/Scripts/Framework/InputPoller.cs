using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Player Number
// #0 : Gamepad Input
// #1 : Keyboard input :: WSAD + QEZC

public class InputPoller : MonoBehaviour
{
    public static InputPoller Self;
    Vector2 ScreenCenter = Vector2.zero;

    void Awake()
    {
        if (Self != null)
        {
            // we have another instance of this system. 
            // the Solution here is to delete the other version 
            Debug.LogWarning("Found another instance of InputPoller on " + Self.name);
            Destroy(Self);
        }
        Self = this;

        ScreenCenter.x = Screen.width; 
        ScreenCenter.y = Screen.height;
        ScreenCenter *= .5f; 
    }

    public InputData GetInput(int PlayerNumber)
    {
        if (PlayerNumber == 0) { return GetInputP0(); }
        if (PlayerNumber == 1) { return GetInputP1(); }
      
        // Defaut return 
        return InputData.CleanDataStruct();
    }

    // This is the First GamePad Connected Info
    public InputData GetInputP0()
    {
        InputData input = InputData.CleanDataStruct();

        Gamepad gpad = Gamepad.current;
        // verify we have gamepad data
        if (gpad != null)
        {
            input.leftStick = gpad.leftStick.ReadValue();
            input.rightStick = gpad.rightStick.ReadValue();
            input.dpad = gpad.dpad.ReadValue();
            input.leftStickButton = gpad.leftStickButton.wasPressedThisFrame;
            input.rightStickButton = gpad.rightStickButton.wasPressedThisFrame;
            input.leftTrigger = gpad.leftTrigger.ReadValue();
            input.rightTrigger = gpad.rightTrigger.ReadValue();
            input.leftShoulder = gpad.leftShoulder.wasPressedThisFrame;
            input.rightShoulder = gpad.rightShoulder.wasPressedThisFrame;
            input.buttonNorth = gpad.buttonNorth.wasPressedThisFrame;
            input.buttonSouth = gpad.buttonSouth.wasPressedThisFrame;
            input.buttonEast = gpad.buttonEast.wasPressedThisFrame;
            input.buttonWest = gpad.buttonWest.wasPressedThisFrame;
            input.startButton = gpad.startButton.wasPressedThisFrame;
            input.selectButton = gpad.selectButton.wasPressedThisFrame;
        }

        return input;
    }

    // this is the Keyboard and Mouse Info
    public InputData GetInputP1()
    {
        InputData input = InputData.CleanDataStruct();

        Keyboard kb = Keyboard.current;
        // Verifiy we have Keyboard data 
        if (kb != null)
        {
            if (kb.wKey.isPressed) { input.leftStick.y = 1; }
            if (kb.sKey.isPressed) { input.leftStick.y = -1; }
            if (kb.aKey.isPressed) { input.leftStick.x = -1; }
            if (kb.dKey.isPressed) { input.leftStick.x = 1; }

            input.buttonNorth = kb.qKey.wasPressedThisFrame;
            input.buttonSouth = kb.eKey.wasPressedThisFrame;
            input.buttonEast = kb.zKey.wasPressedThisFrame;
            input.buttonWest = kb.cKey.wasPressedThisFrame;
        }

        // Emulate the right stick using the mouse

        Mouse mouse = Mouse.current; 
        if (mouse != null) 
        {
            Vector2 Mouselocation = mouse.position.ReadValue();
            input.rightStick = (Mouselocation - ScreenCenter).normalized; 

        }

        return input;
    }
}

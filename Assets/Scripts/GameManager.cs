using UnityEngine;
using System.Collections.Generic;

public class GameManager : Info
{
    public static GameManager self;

    private void Awake()
    {
        self = this;
    }
}
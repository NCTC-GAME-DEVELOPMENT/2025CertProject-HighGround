using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager self;

    private void Awake()
    {
        self = this;
    }
}
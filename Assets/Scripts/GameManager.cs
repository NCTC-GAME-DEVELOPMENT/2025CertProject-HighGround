using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager self;

    private void Awake()
    {
        if (self != null)
        {
            string message = self.gameObject.name + " is already loaded, deleting excess instance";
            Debug.Log(message);

            Destroy(self);
        }
        self = this;
    }
}
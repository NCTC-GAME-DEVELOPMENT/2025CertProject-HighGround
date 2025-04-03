using JetBrains.Annotations;
using UnityEngine;


public class RobotPlayerPW : MonoBehaviour
{
    public int PlayerNumber = 1; 
    public GameObject RobotModel;
    public GameObject ProjectileSpawnPoint;
    public float MoveSpeed = 20f;
    public float RotationSpeed = 180f;
    public float triggerActivateValue = .5f; 

   // public AudioClip someSound;
    AudioSource source;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponentInParent<Rigidbody>();
       source = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        InputData input = InputPoller.Self.GetInput(PlayerNumber);

        MovePlayer(input.leftStick);
        LookandShoot(input.rightStick);
        Fire(input.leftTrigger); 
        Swing(input.rightTrigger);
    }

    public void MovePlayer(Vector2 value)
    {
        if (value.magnitude == 0)
        {
            rb.linearVelocity = Vector3.zero; 
            return;
        }


        Vector3 moveVector = Vector3.zero; 
        moveVector.x = value.x; 
        moveVector.z = value.y;

        rb.linearVelocity = moveVector.normalized * MoveSpeed;
    }

    public void LookandShoot(Vector2 value)
    {
        if(value.magnitude == 0)
        {
            return; 
        }

        Vector3 lookVector = Vector3.zero;
        lookVector.x = value.x;
        lookVector.z = value.y; 
         
        gameObject.transform.forward = lookVector; 
    }
   
    public void Fire(float value)
    {
        if (value > triggerActivateValue)
        {
            Debug.Log("Fire - pew pew pew");

        }
    }
  
    public void Swing(float value)
    {
        // melee attack
        if (value > triggerActivateValue)
        {
            Debug.Log("Swing - swoosh!");

        }
    }
}

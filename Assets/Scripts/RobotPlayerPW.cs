using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class RobotPlayerPW : PWPawn
{
    public GameObject RobotModel;
    public Vector3 DeathRotation;
    public bool RemoveAfterDeath = true;
    public float RemoveAfterDeathTime = 5f;
    public GameObject ProjectileSpawnPoint;
    public float MoveSpeed = 20f;
    public float RotationSpeed = 180f;
   // public AudioClip someSound;
   // AudioSource source;

    Rigidbody rb;

    public static object Instance { get; internal set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
       // source = gameObject.AddComponent<AudioSource>();
    }

    public override void Vertical(float value)
    {
        if (!rb)
        {
            return;
        }

        rb.linearVelocity = gameObject.transform.forward * value * MoveSpeed;
    }

    public override void Horizontal(float value)
    {
        gameObject.transform.Rotate(Vector3.up * value * RotationSpeed * Time.deltaTime);
    }

    public override void Fire(bool value)
    {
        if (value)
        {
            Factory(CurrentProjectile, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation, GetController());
        }
    }
    // the override above maybe subject to change...

    public override void Swing(bool value)
    {
       // melee attack
    }
    // the override above maybe subject to change...

    public override void DeathTest()
    {
        base.DeathTest();
        IgnoresDamage = true;
        controller.BecomeSpectator();
        RobotModel.transform.localRotation = Quaternion.Euler(DeathRotation);
        if (RemoveAfterDeath)
        {
            Destroy(gameObject, RemoveAfterDeathTime);
        }
    }
}

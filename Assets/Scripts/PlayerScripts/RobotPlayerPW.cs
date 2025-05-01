using Unity.VisualScripting;
using UnityEngine;

public class RobotPlayerPW : Actor
{
    public static RobotPlayerPW instance;
    public MeleeAttack metalpipe;

    public int PlayerNumber = 1; 

    public GameObject RobotModel;
    public GameObject projectilePrefab;
    public GameObject WeaponSpawnPoint;

    public float MoveSpeed = 20f;
    public float RotationSpeed = 180f;
    public float triggerActivateValue = .5f; 

    AudioSource source;
    public AudioClip rangeAtkSound;
    public AudioClip meleeAtkSound;

    public float volumeMin = .7f;
    public float volumeMax = 1.0f;
    public float pitchMin = .85f;
    public float pitchMax = 1.15f;

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

    public void PlayWithVariance(AudioClip clip)
    {
        // volume range 
        float clipVolume = Random.Range(volumeMin, volumeMax);
        // pitch range 
        float clipPitch = Random.Range(pitchMin, pitchMax);

        source.volume = clipVolume;
        source.pitch = clipPitch;
        source.PlayOneShot(clip);
    }

    public void Fire(float value)
    {
        if (value > triggerActivateValue)
        {
            Debug.Log("Fire - pew pew pew");
            PlayWithVariance(rangeAtkSound);

            SpawnProjectile();
        }
    }
  
    public void Swing(float value)
    {
        // melee attack
        if (value > triggerActivateValue)
        {
            Debug.Log("Swing - swoosh!");
            PlayWithVariance(meleeAtkSound);

            metalpipe.PerformAttack();
        }
    }

    void SpawnProjectile()
    {
        GameObject go = Instantiate(projectilePrefab, WeaponSpawnPoint.transform.position, WeaponSpawnPoint.transform.rotation);
        RangeAttack rangedAttack = go.GetComponent<RangeAttack>();
        rangedAttack.Owner = this; 
    }
}

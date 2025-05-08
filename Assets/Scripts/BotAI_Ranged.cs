using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static DetectionScript;


public class BotAI_Ranged : BotBase
{
    public delegate void AgentState();
    AgentState currentState;

    public bool IsActive = false; 

    public float TrackPlayerTimer = .3f;
    public float delay = 1f;

    Transform currentTarget;
    NavMeshAgent agent;

    public DetectionScript detect;

    public Transform Player;
    public Transform InvestigatePoint; 
    public GameObject projectilePrefab;
    public GameObject WeaponSpawnPoint;
    public GameObject AttackRange;

    public float triggerActivateValue = .5f;
    public float Rotationspeed = 1.0f;

    AudioSource source;
    public AudioClip rangeAtkSound;
    public AudioClip meleeAtkSound;

    public float volumeMin = .7f;
    public float volumeMax = 1.0f;
    public float pitchMin = .85f;
    public float pitchMax = 1.15f;

    public float withInRange = .25f;
    public Transform[] pathList;
    int pathListIndex = 0;

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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        source = gameObject.AddComponent<AudioSource>();


        if(IsActive)
        {
            EnableBot(); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            // Bot isn't active
            return;
        }

        currentState?.Invoke();
    }

    public void EnableBot()
    {
        IsActive = true;

        EnterRoam();
    }

    public void DisableBot()
    {
        IsActive = false; 
    }


    public override void OnPlayerCollision()
    {
        //Debug.Log("AIB-R Player Collision"); 

        // Face the player! 

        Vector3 targetDirection = Player.position - transform.position;
        float quickTurn = Rotationspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, quickTurn, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        EnterChase(); 

    }


    void EnterRoam()
    {
        Debug.Log("Entered Roam");
        currentState = DoRoam;
        currentTarget = pathList[pathListIndex];
        agent.destination = currentTarget.position;
    }

    void DoRoam()
    {
        if (IsCloseToTarget())
        {
            NextTarget();
        }

        // Rather than Spacebar input here. 
        // There will be a new function to check if Bot has found the player... 
        if (detect.IsInView)
        {
            EnterChase();
        }

    }

    void EnterChase()
    {
        Debug.Log("Entered Chase");
        currentState = DoChase;
        
        
        currentTarget = Player;
        
        agent.destination = currentTarget.position;

        agent.stoppingDistance = 5;

    }

    void DoChase()
    {
       
        if (TrackPlayerTimer > 0f)
        {
            TrackPlayerTimer -= Time.deltaTime;
        }
        else
        {
            if(!detect.IsInView) 
            {
                // WE've lost view of the player
                EnterInvesigate();
                return; 
            
            }


            agent.destination = currentTarget.position;

            TrackPlayerTimer += .3f;
  
        }

        // Rotate to player 
        Vector3 targetDirection = Player.position - transform.position;
        float singleStep = Rotationspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        if (detect.IsInView)
        {
            Fire();
        }




    }

    public void EnterInvesigate()
    {
        
        currentState = DoInvestigate;
        InvestigatePoint.position = Player.position;
        currentTarget = InvestigatePoint; 

        agent.destination = currentTarget.position;

        agent.stoppingDistance = withInRange;
    }

    public void DoInvestigate()
    {


        if (detect.IsInView)
        {
            // Find the player again, chase after them! 
            EnterChase();
        }

        if ( IsCloseToTarget())
        {
            // We've lost track of the player 
            // Go back to Roaming 

            EnterRoam();

        }

    }


    public float GetDistanceTo(Transform Other)
    {
        Vector3 distanceVector =
            Other.transform.position - gameObject.transform.position;
        return distanceVector.magnitude;
    }

    public bool IsCloseToTarget()
    {
        bool result = false;
        if (GetDistanceTo(currentTarget) <= withInRange)
        {
            result = true;
        }
        return result;
    }

    public void NextTarget()
    {
        pathListIndex++;
        if (pathListIndex >= pathList.Length)
        {
            pathListIndex = 0;
        }


        currentTarget = pathList[pathListIndex];
        agent.destination = currentTarget.position;
    }

    public void Fire()
    {
        if (delay > 1f)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            Debug.Log("BOT HAS FIRED");
            SpawnProjectile();

            delay += 1f;

        }

        
            
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, WeaponSpawnPoint.transform.position, WeaponSpawnPoint.transform.rotation);
    }




}

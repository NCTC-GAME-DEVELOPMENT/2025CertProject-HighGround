using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static DetectionScript;


public class BotAI_Ranged : MonoBehaviour
{
    public delegate void AgentState();
    AgentState currentState;

    public bool IsActive = false; 

    public float timeLeft = 1;

    Transform currentTarget;
    NavMeshAgent agent;

    public DetectionScript detect;

    public Transform Player;

    public float Rotationspeed = 1.0f;

    bool SpaceBarInput = false;

    AudioSource source;

    public float withInRange = .25f;
    public Transform[] pathList;
    int pathListIndex = 0;

    



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

        // To Be Removed
        GetInput();

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

    void GetInput()
    {
        Keyboard kb = Keyboard.current;
        if (kb != null)
        {
            SpaceBarInput = kb.spaceKey.wasPressedThisFrame;
        }
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
       
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            agent.destination = currentTarget.position;

            timeLeft += 1;
  
        }

        // Rotate to player 
        Vector3 targetDirection = Player.position - transform.position;
        float singleStep = Rotationspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);


        if (agent.isStopped)
        {
            // Attack Player 
            // You will need a timer to make sure not to spam attacks. 
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




}

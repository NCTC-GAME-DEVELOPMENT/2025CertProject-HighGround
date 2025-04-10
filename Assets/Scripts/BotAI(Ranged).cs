using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class GuardMelee : MonoBehaviour
{
    public delegate void AgentState();
    AgentState currentState;

    public float timeLeft = 1;

    Transform currentTarget;
    NavMeshAgent agent;


    
    public Transform Player;
    public Transform MousePointinWorld;
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
        EnterRoam();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        currentState?.Invoke();

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

        if (SpaceBarInput)
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

using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public float MaxDistance = 15;
    public float ArcDot = .3f;
    public Transform PlayerObject;
    public Transform DirectionalObject;
    public Vector3 DirectionalVector = Vector3.zero;
    public Vector3 ForwardVector = Vector3.zero;
    public float Range = 0;
    public float DotProductValue = 0;

    public bool IsInRange = false;
    public bool IsInArc = false;
    public bool IsInView = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        DirectionalVector = (PlayerObject.position - gameObject.transform.position);
        Range = DirectionalVector.magnitude;
        DirectionalVector = DirectionalVector.normalized;

        DirectionalObject.forward = DirectionalVector;
        ForwardVector = gameObject.transform.forward;

        IsInRange = (Range <= MaxDistance);
        if (!IsInRange)
        {
            IsInArc = false;
            IsInView = false;
            return;
        }

        //      DOT PRODUCT TABLE
        //          In Front = 1
        // To Left = 0      to Right = 0
        //          At Behind = -1 

        DotProductValue = Vector3.Dot(ForwardVector, DirectionalVector);

        IsInArc = (DotProductValue >= ArcDot);
        if (!IsInArc)
        {
            IsInView = false;
            return;
        }

        RaycastHit hit;
        bool hasHit = Physics.Raycast(gameObject.transform.position, DirectionalVector, out hit, MaxDistance);
        if (hasHit)
        {
            
            
            RobotPlayerPW player = hit.collider.gameObject.GetComponentInParent<RobotPlayerPW>();
            if (player)
            {
                IsInView = true;
                
            }
            else
            {
                IsInView = false;
            }
            return;
        }

    }
}

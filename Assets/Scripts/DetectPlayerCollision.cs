using UnityEngine;

public class DetectPlayerCollision : MonoBehaviour
{
    public BotBase bot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            // if it's a trigger, ignore this collision situation
            // This will ingore player's melee attack trigger
            return; 
        }


        RobotPlayerPW player = other.gameObject.GetComponentInParent<RobotPlayerPW>();
        if (player != null)
        {
            //Debug.Log("Fo");
            bot.OnPlayerCollision();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOVerTrigeger : MonoBehaviour
{
    string LoadSceneName = "RetryScreen"; 
    private void OnTriggerEnter(Collider other)
    {
        RobotPlayerPW playerPW = other.gameObject.GetComponentInParent<RobotPlayerPW>();
        if (playerPW)
        {
            SceneManager.LoadScene(LoadSceneName);
        }
    }
}

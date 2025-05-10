using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;



    public string TestLevel1 = "MainLevel";
    public string MainMenuScene = "MainMenu";

    public GameObject MainMenuPanel;
    public GameObject ReturnPanel;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartMainLevel()
    {
        Debug.Log("MainLevel");
        MainMenuPanel.SetActive(false);
        ReturnPanel.SetActive(true);
        SceneManager.LoadScene(TestLevel1);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("MainMenu");
        MainMenuPanel.SetActive(true);
        ReturnPanel.SetActive(false);
        SceneManager.LoadScene(MainMenuScene);
    }
}
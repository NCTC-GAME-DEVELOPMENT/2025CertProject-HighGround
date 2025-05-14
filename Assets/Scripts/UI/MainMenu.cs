using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public string MainLevelScene = "TestLevel1";
    public string MainMenuScene = "MainMenu";
    public string Reload = "RetryScreen";

    public GameObject MainMenuPanel;
    public GameObject LevelPanel;
    public GameObject ReloadPanel;

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

    public void QuitApplication()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    public void StartMainLevel()
    {
        Debug.Log("TestLevel1");
        MainMenuPanel.SetActive(false);
        LevelPanel.SetActive(true);
        ReloadPanel.SetActive(false);
        SceneManager.LoadScene(MainLevelScene);
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("MainMenu");
        MainMenuPanel.SetActive(true);
        LevelPanel.SetActive(false);
        ReloadPanel.SetActive(false);
        SceneManager.LoadScene(MainMenuScene);
    }

    public void Retry()
    {
        Debug.Log("RetryScreen");
        MainMenuPanel.SetActive(false);
        LevelPanel.SetActive(false);
        ReloadPanel.SetActive(true);
        SceneManager.LoadScene(Reload);
    }
}
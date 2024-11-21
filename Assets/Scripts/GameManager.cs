using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    public GameObject scoreManagerPrefab;
    private string _pauseMenuSceneName = "Pause";
    private string _restartRound = "RestartRound";
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
{
    if (ScoreManager.Instance == null)
    {
        Instantiate(scoreManagerPrefab);
    }
}
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartRoundDelay(float restartDelay)
    {
        Invoke(_restartRound, restartDelay);
    }
    private void RestartRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.Instance.ResetScore();
    }
    public void QuitGame()
    {
        Debug.Log("Closing game...");
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; 
        SceneManager.LoadScene(_pauseMenuSceneName, LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(_pauseMenuSceneName);
    }
}

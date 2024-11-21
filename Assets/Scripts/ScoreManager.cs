using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("ScoreManager");
                go.AddComponent<ScoreManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private int score = 0;
    private int highscore = 0;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI highScoreText; 

     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        if (highScoreText != null)
        {
            highScoreText.text = "Highscore: " + highscore.ToString();
        }
    }
    public void ResetScore()
    {
        if(highscore < score)
        {
            highscore = score;
        }
        score = 0;
        UpdateScoreDisplay();
    }
}

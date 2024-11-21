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
            }
            return _instance;
        }
    }

    public int score = 100;
    public TextMeshProUGUI scoreText; 

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        if (scoreText == null)
        {    
            if (scoreText == null)
            {
                Debug.LogError("Score Text UI element is not assigned!");
            }
        }           
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
    }
}

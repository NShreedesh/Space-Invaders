using TMPro;
using UnityEngine;

public class ScoreManager : SceneLoadManager
{
    public static ScoreManager Instance { get; private set; }

    [Header("Score Info")]
    [SerializeField] private TMP_Text scoreText;
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateScore(int updateValue)
    {
        score += updateValue;
        scoreText.text = score.ToString();
    }

    public void SetScoreWhenPlayerDies()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}

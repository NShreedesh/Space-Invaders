using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : SceneLoadManager
{
    public static HealthManager Instance { get; private set; }

    [Header("Score Info")]
    [SerializeField] private Image[] healthImages;
    [SerializeField] private int health;
    public int Health { get { return health; } }


    [Header("After Player Death")]
    [SerializeField] private Canvas deathUICanvas;
    [SerializeField] private Button playAgainButton;

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

    private void Start()
    {
        deathUICanvas.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(PlayAgain);

        SetHealth();
    }

    public void UpdateHealth()
    {
        health -= 1;

        if (health >= 0)
        {
            healthImages[health].gameObject.SetActive(false);

            if (health <= 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        GameManager.Instance.ChangeGameState(GameState.Stop);

        deathUICanvas.gameObject.SetActive(true);
    }

    private void PlayAgain()
    {
        GameManager.Instance.ChangeGameState(GameState.Play);
        deathUICanvas.gameObject.SetActive(false);

        SetHealth();
        SetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetHealth()
    {
        health = healthImages.Length;
        foreach (var image in healthImages)
        {
            image.gameObject.SetActive(true);
        }
    }

    private void SetScore()
    {
        ScoreManager.Instance.SetScoreWhenPlayerDies();
    }
}

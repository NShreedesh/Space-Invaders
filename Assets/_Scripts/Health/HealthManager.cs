using UnityEngine;
using UnityEngine.UI;

public class HealthManager : SceneLoadManager
{
    public static HealthManager Instance { get; private set; }

    [Header("Score Info")]
    [SerializeField] private Image[] healthImages;
    [SerializeField] private int health;
    public int Health { get { return health; } }

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
        SetHealth();
    }

    public void UpdateHealth(Animator playerAnimator)
    {
        health -= 1;

        if (health >= 0)
        {
            healthImages[health].gameObject.SetActive(false);

            if (health <= 0)
            {
                Dead();
                playerAnimator.SetBool("dead", true);
            }
        }
    }

    private void Dead()
    {
        GameManager.Instance.ChangeGameState(GameState.GameOver);
    }

    public void SetHealth()
    {
        health = healthImages.Length;
        foreach (var image in healthImages)
        {
            image.gameObject.SetActive(true);
        }
    }
}

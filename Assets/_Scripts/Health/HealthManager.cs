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
        health = healthImages.Length;
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
    }
}

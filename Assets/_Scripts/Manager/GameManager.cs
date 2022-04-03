using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Pause, Play, GameOver, Win
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("GameState Info")]
    public GameState gameState;

    [Header("After Player Death")]
    [SerializeField] private Canvas deathUICanvas;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private TMP_Text infoText;

    [Header("Pause Time Info")]
    [SerializeField] protected float pauseAfterDamageTime = 0.3f;
    private WaitForSeconds waitForPauseAfterDamage;

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

    private void OnEnable()
    {
        waitForPauseAfterDamage = new WaitForSeconds(pauseAfterDamageTime);
        SceneManager.sceneLoaded += NewSceneLoaded;
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        deathUICanvas.gameObject.SetActive(false);
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;

        if (gameState == GameState.GameOver)
        {
            infoText.text = "Game Over!!!";
            deathUICanvas.gameObject.SetActive(true);
            AudioManager.Instance.Stop_RedInvaderSpawnEffectAudio();
        }
        else if (gameState == GameState.Win)
        {
            infoText.text = "Level Completed!!!";
            deathUICanvas.gameObject.SetActive(true);
            AudioManager.Instance.Stop_RedInvaderSpawnEffectAudio();
        }
    }

    public IEnumerator ChangeGameStateToPauseAndPlay(GameState state)
    {
        gameState = state;
        yield return waitForPauseAfterDamage;
        gameState = GameState.Play;
    }

    private void PlayAgain()
    {
        deathUICanvas.gameObject.SetActive(false);

        HealthManager.Instance.SetHealth();
        ScoreManager.Instance.SetScoreWhenPlayerDies();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NewSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 0)
        {
            ChangeGameState(GameState.Pause);
        }
        else if (arg0.buildIndex == 1)
        {
            ChangeGameState(GameState.Play);
        }
    }
}

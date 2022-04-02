using System.Collections;
using UnityEngine;

public enum GameState
{
    Pause, Play, Stop
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("GameState Info")]
    public GameState gameState;

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
        gameState = GameState.Play;
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
    }

    public IEnumerator ChangeGameStateToPauseAndPlay(GameState state, float waitTime)
    {
        gameState = state;
        yield return new WaitForSeconds(waitTime);
        gameState = GameState.Play;
    }
}

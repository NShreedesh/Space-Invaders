using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        GameManager.Instance.ChangeGameState(GameState.Play);
        SceneManager.LoadScene(1);
    }
}

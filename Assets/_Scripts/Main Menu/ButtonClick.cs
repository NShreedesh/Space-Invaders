using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(PlayButtonClicked);
    }

    private void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}

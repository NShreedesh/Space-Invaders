using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [Header("Health UI")]
    [SerializeField] private GameObject canvasToEnableAndDisableDuringSceneChange;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += NewSceneLoaded;
    }

    private void NewSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 0)
        {
            canvasToEnableAndDisableDuringSceneChange.SetActive(false);
        }
        else if (arg0.buildIndex == 1)
        {
            canvasToEnableAndDisableDuringSceneChange.SetActive(true);
        }
    }
}

using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private ObjectPooling pool;

    [Header("Shooting Audio")]
    [SerializeField] private AudioClip shootingAudioClip;

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Play) return;

        if (controller.PlayerInput.InputControl.Player.Shoot.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        foreach (var obj in pool.SpawnningObjectList)
        {
            if (obj.activeSelf)
            {
                return;
            }
            else
            {
                pool.EnableObjects();
                AudioManager.Instance.Play_PlayerShootAudio(shootingAudioClip);
                return;
            }
        }
    }
}

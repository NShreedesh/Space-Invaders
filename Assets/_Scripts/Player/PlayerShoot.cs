using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    [Header("Shooting Time")]
    [SerializeField] private float waitTillShootTime;
    private float _shootTime;

    [Header("Shooting Audio")]
    [SerializeField] private AudioClip shootingAudioClip;

    private void Update()
    {
        if(_shootTime  > 0)
        {
            _shootTime -= Time.deltaTime;
        }

        if(_shootTime <= 0 && controller.PlayerInput.InputControl.Player.Shoot.triggered)
        {
            Shoot();
            _shootTime = waitTillShootTime;
        }
    }

    private void Shoot()
    {
        ObjectPooling.Instance.EnableObjects();
        AudioManager.Instance.Play_PlayerShootAudio(shootingAudioClip);
    }
}

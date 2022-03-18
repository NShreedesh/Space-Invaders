using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (controller.PlayerInput.InputControl.Player.Shoot.triggered)
        {
            var bulletObject = ObjectPooling.Instance.EnableObjects();

            if (bulletObject == null)
                return;
        }
    }
}

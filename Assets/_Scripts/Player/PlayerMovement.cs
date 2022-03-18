using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private PlayerController controller;

    [Header("Movement")]
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x > ScreenPositionHelper.Instance.ScreenLeft.x + 0.5f && controller.PlayerInput.MovementInput < 0)
        {
            transform.position += Vector3.right * speed * controller.PlayerInput.MovementInput * Time.deltaTime;
        }
        else if (transform.position.x < ScreenPositionHelper.Instance.ScreenRight.x - 0.5f && controller.PlayerInput.MovementInput > 0)
        {
            transform.position += Vector3.right * speed * controller.PlayerInput.MovementInput * Time.deltaTime;
        }
    }
}

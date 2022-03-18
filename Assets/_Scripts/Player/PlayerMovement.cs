using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private PlayerController controller;

    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Screen Position")]
    private float _screenLeft;
    private float _screenRight;

    private void Start()
    {
        ScreenPositionHelper.Instance.CalculateScreenSides(out _screenLeft, out _screenRight);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x > _screenLeft + 0.5f && controller.PlayerInput.MovementInput < 0)
        {
            transform.position += Vector3.right * speed * controller.PlayerInput.MovementInput * Time.deltaTime;
        }
        else if (transform.position.x < _screenRight - 0.5f && controller.PlayerInput.MovementInput > 0)
        {
            transform.position += Vector3.right * speed * controller.PlayerInput.MovementInput * Time.deltaTime;
        }
    }
}

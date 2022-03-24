using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private EnemyController controller;

    [Header("Movement Info")]
    [SerializeField] private float offset = 0.25f;
    [SerializeField] private float movementSpeed = 1;
    private bool _moveLeft;

    private void Start()
    {
        InvokeRepeating(nameof(Move), movementSpeed, movementSpeed);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Move()
    {
        if (controller.leftEnemy.transform.position.x <= ScreenPositionHelper.Instance.ScreenLeft.x + 0.5f && _moveLeft)
        {
            transform.position -= new Vector3(0, offset, 0);
            controller.InvaderAnimation();
            _moveLeft = false;
            return;
        }

        if (controller.rightEnemy.transform.position.x >= ScreenPositionHelper.Instance.ScreenRight.x - 0.5f && !_moveLeft)
        {
            transform.position -= new Vector3(0, offset, 0);
            controller.InvaderAnimation();
            _moveLeft = true;
            return;
        }

        if (_moveLeft)
        {
            transform.position -= new Vector3(offset, 0, 0);
            controller.InvaderAnimation();
        }
        else
        {
            transform.position += new Vector3(offset, 0, 0);
            controller.InvaderAnimation();
        }
    }
}

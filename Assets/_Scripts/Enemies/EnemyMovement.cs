using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private EnemyController controller;

    [Header("Movement Info")]
    [SerializeField] private float offset = 0.25f;
    [SerializeField] private float movementSpeed = 1;
    private bool _moveLeft;

    [Header("Audio Info")]
    [SerializeField] private AudioClip[] movementAudioClip;
     
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
            MoveVertically(false);
            return;
        }

        if (controller.rightEnemy.transform.position.x >= ScreenPositionHelper.Instance.ScreenRight.x - 0.5f && !_moveLeft)
        {
            MoveVertically(true);
            return;
        }

        // change position of invaders parent with certain amount of offset.
        if (_moveLeft)
        {
            MoveHorizontally(-offset);
        }
        else
        {
            MoveHorizontally(offset);
        }
    }

    private void MoveHorizontally(float offsetToMove)
    {
        transform.position += new Vector3(offsetToMove, 0, 0);
        PlayMovementAudio();
        controller.InvaderAnimation();
    }

    private void MoveVertically(bool moveLeft)
    {
        transform.position -= new Vector3(0, offset, 0);
        PlayMovementAudio();
        controller.InvaderAnimation();
        _moveLeft = moveLeft;
    }

    private void PlayMovementAudio()
    {
        int movementClipCount = Random.Range(0, 4);
        AudioManager.Instance.Play_EnemyMovementAudio(movementAudioClip[movementClipCount]);
    }
}

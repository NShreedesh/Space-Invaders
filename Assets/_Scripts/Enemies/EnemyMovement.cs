using System.Collections;
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

    [Header("SpeedBoosting Info")]
    [SerializeField] private float speedBoostAfterTime = 10;
    [SerializeField] private float maxSpeed = 0.2f;
    [SerializeField] private float deacreaseSpeedBy = 0.05f;

    private void Start()
    {
        StartCoroutine(Move());
        InvokeRepeating(nameof(SpeedBoosting), speedBoostAfterTime, speedBoostAfterTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (GameManager.Instance.gameState != GameState.Play) yield return new WaitUntil(() => GameManager.Instance.gameState == GameState.Play);

            if (controller.leftEnemy.transform.position.x <= ScreenPositionHelper.Instance.ScreenLeft.x + 0.5f && _moveLeft)
            {
                MoveVertically(false);
                yield return new WaitForSeconds(movementSpeed);
            }

            if (controller.rightEnemy.transform.position.x >= ScreenPositionHelper.Instance.ScreenRight.x - 0.5f && !_moveLeft)
            {
                MoveVertically(true);
                yield return new WaitForSeconds(movementSpeed);
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

            yield return new WaitForSeconds(movementSpeed);
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

    private void SpeedBoosting()
    {
        if (movementSpeed <= maxSpeed)
        {
            CancelInvoke();
            return;
        }
        movementSpeed -= deacreaseSpeedBy;
    }
}

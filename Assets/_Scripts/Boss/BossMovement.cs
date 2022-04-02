using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private EnemyHit enemyHit;

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Play)
        {
            return;
        }

        Move();

        if (ScreenPositionHelper.Instance.ScreenRight.x + 1 < transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (enemyHit.isDead)
        {
            AudioManager.Instance.Stop_RedInvaderSpawnEffectAudio();
            return;
        }

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.Stop_RedInvaderSpawnEffectAudio();
    }
}

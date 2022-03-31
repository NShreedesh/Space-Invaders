using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent<EnemyHit>(out EnemyHit enemyHit))
            {
                enemyHit.TakeDamage();
                bulletController.DisableBullet();
            }
        }

        else if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
            {
                playerHit.TakeDamage();
                 bulletController.DisableBullet();
            }
        }
    }
}

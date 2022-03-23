using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent<EnemyHit>(out EnemyHit enemyHealth))
            {
                enemyHealth.TakeDamage();
                bulletController.DisableBullet();
            }
        }
    }
}

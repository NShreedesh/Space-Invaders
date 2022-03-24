using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [Range(0, 2)]
    public int enemyNumber;

    [Header("Bullet Hit")]
    [SerializeField] private AudioClip bulletHit;

    public void TakeDamage()
    {
        AudioManager.Instance.PlayOneShotAudio(bulletHit);

        Destroy(gameObject);
    }
}

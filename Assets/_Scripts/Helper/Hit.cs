using UnityEngine;

public class Hit : MonoBehaviour
{
    [Header("Bullet Hit")]
    [SerializeField] private AudioClip bulletHit;

    public virtual void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
    }
}

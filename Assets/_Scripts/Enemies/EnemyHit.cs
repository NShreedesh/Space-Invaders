using UnityEngine;

public class EnemyHit : Hit
{
    [Header("Score Info")]
    [SerializeField] private int pointForEnemy;

    public void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        ScoreManager.Instance.UpdateScore(pointForEnemy);
        Destroy(gameObject);
    }
}

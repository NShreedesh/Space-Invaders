using UnityEngine;

public class EnemyHit : Hit
{
    [Header("Score Info")]
    [SerializeField] private int pointForEnemy;

    public override void TakeDamage()
    {
        base.TakeDamage();

        ScoreManager.Instance.UpdateScore(pointForEnemy);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PlayerHit : Hit
{
    [Header("Animator Info")]
    [SerializeField] private Animator anim;

    public void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        HealthManager.Instance.UpdateHealth(anim);

        if (HealthManager.Instance.Health > 1)
        {
            StartCoroutine(GameManager.Instance.ChangeGameStateToPauseAndPlay(GameState.GameOver, pauseAfterDamageTime));
        }
    }
}

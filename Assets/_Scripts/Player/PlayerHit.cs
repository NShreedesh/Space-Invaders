public class PlayerHit : Hit
{
    public void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        HealthManager.Instance.UpdateHealth();

        if (HealthManager.Instance.Health > 1)
        {
            StartCoroutine(GameManager.Instance.ChangeGameStateToPauseAndPlay(GameState.Stop, pauseAfterDamageTime));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Hit
{
    public void TakeDamage()
    {
        StartCoroutine(GameManager.Instance.ChangeGameStateToPauseAndPlay(GameState.Pause, pauseAfterDamageTime));

        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        HealthManager.Instance.UpdateHealth();
    }
}

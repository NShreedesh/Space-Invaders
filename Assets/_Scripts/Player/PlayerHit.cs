using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Hit
{
    public void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        HealthManager.Instance.UpdateHealth();
    }
}

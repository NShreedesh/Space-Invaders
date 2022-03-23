using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [Header("Bullet Hit")]
    [SerializeField] private AudioClip bulletHit;

    public void TakeDamage()
    {
        AudioManager.Instance.PlayOneShotAudio(bulletHit);
        Destroy(gameObject);
    }
}

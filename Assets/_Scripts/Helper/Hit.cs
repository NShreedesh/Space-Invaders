using UnityEngine;

public class Hit : MonoBehaviour
{
    [Header("Bullet Hit")]
    [SerializeField] protected AudioClip bulletHit;
    [HideInInspector] public bool isDead;

    [Header("Pause Time Info")]
    [SerializeField] protected float pauseAfterDamageTime = 0.3f;
}

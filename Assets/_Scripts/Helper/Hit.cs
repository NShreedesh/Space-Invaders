using UnityEngine;

public class Hit : MonoBehaviour
{
    [Header("Bullet Hit")]
    [SerializeField] protected AudioClip bulletHit;
    [HideInInspector] public bool isDead;
}

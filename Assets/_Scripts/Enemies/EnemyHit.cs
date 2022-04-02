using System;
using TMPro;
using UnityEngine;

public class EnemyHit : Hit
{
    [Header("Component Info")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Score Info")]
    [SerializeField] private int pointForEnemy;

    [Header("Child Point Text Info")]
    [SerializeField] private TMP_Text pointText;

    [Header("Enemy Removal Info")]
    [SerializeField] private float removeEnemyAfterTime = 1;

    private void Start()
    {
        pointText.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void TakeDamage()
    {
        AudioManager.Instance.Play_EnemyDeadAudio(bulletHit);
        ScoreManager.Instance.UpdateScore(pointForEnemy);

        if (HealthManager.Instance.Health > 1)
        {
            StartCoroutine(GameManager.Instance.ChangeGameStateToPauseAndPlay(GameState.Pause, pauseAfterDamageTime));
        }

        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        pointText.text = pointForEnemy.ToString();
        pointText.gameObject.SetActive(true);

        isDead = true;
        Invoke(nameof(RemoveEnemy), removeEnemyAfterTime);
    }

    private void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}

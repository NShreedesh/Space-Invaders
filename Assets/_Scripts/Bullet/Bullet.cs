using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Bullet Info")]
    [SerializeField] private float speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        BulletVelocity();
        Invoke(nameof(DisableBullet), 3);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void BulletVelocity()
    {
        _rb.velocity = Vector2.zero;
        transform.SetParent(null);
        _rb.velocity = Vector2.up * speed;
    }

    private void DisableBullet()
    {
        transform.SetParent(ObjectPooling.Instance.ParentForSpawnningObject);
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
    }
}

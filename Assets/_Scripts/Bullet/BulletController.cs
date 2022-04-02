using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Bullet Info")]
    [SerializeField] private float speed;

    private Transform _parentForTheBullet;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _parentForTheBullet = transform.parent;

        BulletVelocity();
    }

    private void Update()
    {
        if (!gameObject.activeSelf) return;

        if(transform.position.y >= -ScreenPositionHelper.Instance.ScreenLeft.y + 0.3f ||
           transform.position.y <= ScreenPositionHelper.Instance.ScreenLeft.y - 0.3f)
        {
            DisableBullet();
        }
    }

    private void BulletVelocity()
    {
        _rb.velocity = Vector2.zero;
        transform.SetParent(null);
        _rb.velocity = Vector2.up * speed;
    }

    public void DisableBullet()
    {
        transform.SetParent(_parentForTheBullet);
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
    }
}

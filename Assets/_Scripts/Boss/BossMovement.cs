using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}

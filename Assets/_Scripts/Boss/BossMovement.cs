using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Move();

        if(ScreenPositionHelper.Instance.ScreenRight.x + 1 < transform.position.x)
        {
            Destroy(gameObject);
            AudioManager.Instance.Stop_RedInvaderSpawnEffectAudio();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private ObjectPooling pool;

    [Header("Shooting Time")]
    private float _waitTillShootTime;
    [SerializeField] private float minWaitTillShootTime;
    [SerializeField] private float maxWaitTillShootTime;
    private float _shootTime;

    [Header("Shooting Audio")]
    [SerializeField] private AudioClip shootingAudioClip;

    [Header("Shooter Invader Info")]
    [SerializeField] private GameObject shooterInvaderParent;
    [SerializeField] private int howManyShooterShootsAtOnce = 2;
    private List<int> _noOfShooter = new List<int>();
    private int _previousRandomShooter;
    private int _randomShooter;

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Play) return;


        if (_shootTime > 0)
        {
            _shootTime -= Time.deltaTime;
        }

        if (_shootTime <= 0 && shooterInvaderParent.transform.childCount > 0)
        {
            Shoot();
            _waitTillShootTime = Random.Range(minWaitTillShootTime, maxWaitTillShootTime);
            _shootTime = _waitTillShootTime;
        }
    }

    private void Shoot()
    {
        _noOfShooter.Clear();

        // Selecting totally random numbers but currently only works for 2 bullets.
        for (int i = 0; i < howManyShooterShootsAtOnce; i++)
        {
            int childCount = shooterInvaderParent.transform.childCount;
            _randomShooter = Random.Range(0, childCount);
            if(childCount > 1)
            {
                while (_previousRandomShooter == _randomShooter)
                {
                    _randomShooter = Random.Range(0, shooterInvaderParent.transform.childCount);
                }
            }

            _noOfShooter.Add(_randomShooter);

            _previousRandomShooter = _randomShooter;
        }


        for (int i = 0; i < _noOfShooter.Count; i++)
        {
            GameObject bullet = pool.EnableObjects();

            bullet.transform.position = shooterInvaderParent.transform.GetChild(_noOfShooter[i]).transform.position;
            AudioManager.Instance.Play_PlayerShootAudio(shootingAudioClip);
        }
    }
}

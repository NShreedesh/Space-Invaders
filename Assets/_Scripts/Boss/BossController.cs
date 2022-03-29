using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Boss Info")]
    [SerializeField] private GameObject redInvaderPrefab;
    [SerializeField] private int totalNumberOfBoss;

    [Header("Time For Boss Spawn Info")]
    [SerializeField] private int firstBossSpawnTime = 10;
    [SerializeField] private int otherBossSpawnTime = 15;
    private WaitForSeconds _waitForSecondsForFirstBoss;
    private WaitForSeconds _waitForSecondsForOtherBoss;


    private void Start()
    {
        _waitForSecondsForFirstBoss = new WaitForSeconds(firstBossSpawnTime);
        _waitForSecondsForOtherBoss = new WaitForSeconds(otherBossSpawnTime);

        StartCoroutine(SpawnBoss());
    }

    private IEnumerator SpawnBoss()
    {
        for(int i = 0; i < totalNumberOfBoss; i++)
        {
            if (totalNumberOfBoss > 0)
            {
                yield return _waitForSecondsForFirstBoss;

                Instantiate(redInvaderPrefab, new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x - 1,
                    -ScreenPositionHelper.Instance.ScreenLeft.y - 2),
                    Quaternion.identity,
                    transform);
            }

            yield return _waitForSecondsForOtherBoss;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

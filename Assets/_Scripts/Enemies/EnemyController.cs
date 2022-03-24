using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Prefab Info")]
    [SerializeField] private GameObject[] invadersPrefabs;

    [Header("Position Info")]
    [SerializeField] private int columnCount;

    [Header("Spacing Info")]
    [Range(0.5f, 1f)]
    [SerializeField] private float startingXSpacing;
    [Range(0.5f, 1f)]
    [SerializeField] private float inBetweenXSpacing;
    [Range(0.5f, 1f)]
    [SerializeField] private float inBetweenYSpacing;
    private float _xPosition;
    private float _yPosition;

    [Header("Camera Info")]
    [SerializeField] private Camera cam;

    [Header("Enemy Position Info")]
    [HideInInspector] public GameObject leftEnemy;
    [HideInInspector] public GameObject rightEnemy;

    [Header("Invader List Info")]
    [SerializeField] private InvaderInfo[] invaderInfo;
    private SpriteRenderer[,] invaderList;

    private void Start()
    {
        _xPosition = startingXSpacing;
        invaderList = new SpriteRenderer[columnCount, invadersPrefabs.Length];

        EnemySpawn();
    }

    private void EnemySpawn()
    {
        //Spawn Enemy (rowCount = invadersPrefab.Length)
        for (int y = 0; y < invadersPrefabs.Length; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                // Spawn Left and right enemy for checking the position with screen during movement.
                if (y == 0 && x == 0)
                {
                    leftEnemy = new GameObject();
                    leftEnemy.transform.parent = transform;
                    leftEnemy.transform.position = new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition);
                }

                GameObject spawnnedInvader = Instantiate(invadersPrefabs[y], new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition), Quaternion.identity, transform);
                invaderList[x, y] = spawnnedInvader.GetComponent<SpriteRenderer>();

                if (y == invadersPrefabs.Length - 1 && x == columnCount - 1)
                {
                    rightEnemy = new GameObject();
                    rightEnemy.transform.parent = transform;
                    rightEnemy.transform.position = new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition);
                }

                _xPosition += inBetweenXSpacing;
            }
            _xPosition = startingXSpacing;
            _yPosition += inBetweenYSpacing;
        }

        // Take Camera in middle position horizontally and calculate new screen sides.
        float leftInvaderPosition = ScreenPositionHelper.Instance.ScreenLeft.x + startingXSpacing;
        float rightInvaderPosition = ScreenPositionHelper.Instance.ScreenLeft.x + startingXSpacing * columnCount;
        float mid = (leftInvaderPosition + rightInvaderPosition) / 2;
        cam.transform.position = new Vector3(mid, cam.transform.position.y, cam.transform.position.z);
        ScreenPositionHelper.Instance.CalculateScreenSides();

        // Put all the Invaders inside of a screen increaing camear's orthographic size.
        while (leftInvaderPosition <= ScreenPositionHelper.Instance.ScreenLeft.x + 1)
        {
            cam.orthographicSize++;
            ScreenPositionHelper.Instance.CalculateScreenSides();
        }

        // Enemy vertically positioning some steps down from top of the screen.
        transform.position = new Vector2(transform.position.x, -ScreenPositionHelper.Instance.ScreenLeft.y - _yPosition - 2);
    }

    public void InvaderAnimation()
    {
        for (int y = 0; y < invadersPrefabs.Length; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                if (invaderList[x, y] == null) continue;

                var enemyHit = invaderList[x, y].GetComponent<EnemyHit>();
                if (enemyHit == null) return;

                if(invaderList[x, y].sprite == invaderInfo[enemyHit.enemyNumber].sprite[0])
                {
                    invaderList[x, y].sprite = invaderInfo[enemyHit.enemyNumber].sprite[1];
                }
                else if(invaderList[x, y].sprite == invaderInfo[enemyHit.enemyNumber].sprite[1])
                {
                    invaderList[x, y].sprite = invaderInfo[enemyHit.enemyNumber].sprite[0];
                }
            }
        }
    }
}

[System.Serializable]
public class InvaderInfo
{
    public string name;
    public Sprite[] sprite;
}
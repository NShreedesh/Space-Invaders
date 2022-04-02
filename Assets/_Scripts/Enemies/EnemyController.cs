using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Prefab Info")]
    [SerializeField] private GameObject[] invadersPrefabs;

    [Header("Position Info")]
    [SerializeField] private int columnCount;

    [Header("Invader Parent Info")]
    [SerializeField] private Transform invadersSpawnParent1;
    [SerializeField] private Transform invadersSpawnParent2;
    [SerializeField] private Transform invadersSpawnParent3;

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

        InvokeRepeating(nameof(InvaderScanLeft), 1, 1);
        InvokeRepeating(nameof(InvaderScanRight), 1, 1);
    }

    private void Update()
    {
        if (CheckForAllEnemyDead() && GameManager.Instance.gameState != GameState.Stop)
        {
            GameManager.Instance.ChangeGameState(GameState.Stop);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
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
                    leftEnemy.name = "LeftEnemyPosition";
                    leftEnemy.transform.parent = transform;
                    leftEnemy.transform.position = new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition);
                }

                GameObject spawnnedInvader = Instantiate(invadersPrefabs[y], new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition), Quaternion.identity);

                // Assign Enemy Parents for different kind.
                var enemyInfo = spawnnedInvader.GetComponent<EnemyInfo>();
                if (enemyInfo.enemyNumber == 0)
                {
                    spawnnedInvader.transform.parent = invadersSpawnParent1;
                }
                else if(enemyInfo.enemyNumber == 1)
                {
                    spawnnedInvader.transform.parent = invadersSpawnParent2;
                }
                else if(enemyInfo.enemyNumber == 2)
                {
                    spawnnedInvader.transform.parent = invadersSpawnParent3;
                }

                invaderList[x, y] = spawnnedInvader.GetComponent<SpriteRenderer>();

                if (y == invadersPrefabs.Length - 1 && x == columnCount - 1)
                {
                    rightEnemy = new GameObject();
                    rightEnemy.name = "RightEnemyPosition";
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

                var enemyInfo = invaderList[x, y].GetComponent<EnemyInfo>();
                if (enemyInfo == null) return;

                if(invaderList[x, y].sprite == invaderInfo[enemyInfo.enemyNumber].sprite[0])
                {
                    invaderList[x, y].sprite = invaderInfo[enemyInfo.enemyNumber].sprite[1];
                }
                else if(invaderList[x, y].sprite == invaderInfo[enemyInfo.enemyNumber].sprite[1])
                {
                    invaderList[x, y].sprite = invaderInfo[enemyInfo.enemyNumber].sprite[0];
                }
            }
        }
    }

    // Scans from left and leftEnemy Position moves to new Position.
    private void InvaderScanLeft()
    {
        for (int x = 0; x < columnCount; x++)
        {
            for (int y = 0; y < invadersPrefabs.Length; y++)
            {
                if(invaderList[x, y] == null) continue;

                else
                {
                    leftEnemy.transform.position = invaderList[x, y].transform.position;
                    return;
                }
            }
        }
    }

    // Scans from right and leftEnemy Position moves to new Position.
    private void InvaderScanRight()
    {
        for (int x = columnCount - 1; x >= 0; x--)
        {
            for (int y = 0; y < invadersPrefabs.Length; y++)
            {
                if (invaderList[x, y] == null) continue;

                else
                {
                    rightEnemy.transform.position = invaderList[x, y].transform.position;
                    return;
                }
            }
        }
    }
    

    //Check if all the enemies are killed.
    private bool CheckForAllEnemyDead()
    {
        bool check1 = CheckForEnemies(invadersSpawnParent1);
        bool check2 = CheckForEnemies(invadersSpawnParent2);
        bool check3 = CheckForEnemies(invadersSpawnParent3);

        return true ? check1 && check2 && check3 : false;
    }

    private bool CheckForEnemies(Transform transformToCheck)
    {
        if(transformToCheck.childCount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

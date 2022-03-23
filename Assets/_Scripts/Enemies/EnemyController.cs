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

    private void Start()
    {
        _xPosition = startingXSpacing;

        EnemySpawn();
    }

    private void EnemySpawn()
    {
        //Spawn Enemy (rowCount = invadersPrefab.Length)
        for (int y = 0; y < invadersPrefabs.Length; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                Instantiate(invadersPrefabs[y], new Vector2(ScreenPositionHelper.Instance.ScreenLeft.x + _xPosition, _yPosition), Quaternion.identity, transform);
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
}
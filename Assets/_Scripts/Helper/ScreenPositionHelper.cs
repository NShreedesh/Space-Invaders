using UnityEngine;

public class ScreenPositionHelper : MonoBehaviour
{
    public static ScreenPositionHelper Instance { get; private set; }

    [Header("Camera Info")]
    [SerializeField] private Camera cam;

    [Header("Screen Info")]
    [SerializeField] private Vector2 screenLeft;
    public Vector2 ScreenLeft => screenLeft;

    [SerializeField] private Vector2 screenRight;
    public Vector2 ScreenRight => screenRight;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
        }

        CalculateScreenSides();
    }

    public void CalculateScreenSides()
    {
        screenLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        screenRight = cam.ViewportToWorldPoint(new Vector2(1, 0));
    }
}

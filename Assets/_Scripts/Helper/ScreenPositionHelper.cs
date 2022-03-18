using UnityEngine;

public class ScreenPositionHelper : MonoBehaviour
{
    public static ScreenPositionHelper Instance { get; private set; }

    [SerializeField] private Camera cam;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }

    public void CalculateScreenSides(out float screenLeft, out float screenRight)
    {
        var screeLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        var screeRight = cam.ViewportToWorldPoint(new Vector2(1, 0));

        screenLeft = screeLeft.x;
        screenRight = screeRight.x;
    }
}

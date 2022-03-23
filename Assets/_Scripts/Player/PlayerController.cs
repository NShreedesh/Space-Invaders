using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    public PlayerInput PlayerInput => playerInput;

    private void Start()
    {
        PlayerPosition();
    }

    private void PlayerPosition()
    {
        float midPosition = (ScreenPositionHelper.Instance.ScreenLeft.x + ScreenPositionHelper.Instance.ScreenRight.x) / 2;
        float bottomPosition = ScreenPositionHelper.Instance.ScreenLeft.y + 1.5f;
        transform.position = new Vector2(midPosition, bottomPosition);
    }
}

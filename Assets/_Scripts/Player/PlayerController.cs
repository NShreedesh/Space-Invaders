using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    public PlayerInput PlayerInput => playerInput;
}

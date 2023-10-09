using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprinting : MonoBehaviour
{
    Player player;
    PlayerInput playerInput;
    InputAction sprintAction;

    void Awake()
    {
        player = GetComponent<player>();
        playerInput = GetComponent<playerInput>();
        sprintAction = player; 
    }
}

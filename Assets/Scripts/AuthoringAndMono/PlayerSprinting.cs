using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSprinting : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 2f;

    PlayerMovement playerMovement;
    PlayerInput playerInput;
    InputAction sprintAction;

    void Awake()
    {

        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["sprint"];
    }

    void OnEnable() => playerMovement.OnBeforeMove += OnBeforeMove;
    void OnDisable() => playerMovement.OnBeforeMove -= OnBeforeMove;

    void OnBeforeMove()
    {
        var sprintInput = sprintAction.ReadValue<float>();
        if (sprintInput == 0) return; 
        var forwardMovementFactor = Mathf.Clamp01(
            Vector3.Dot(playerMovement.transform.forward, playerMovement.velocity.normalized)
            );
        var multiplier = Mathf.Lerp(1f, speedMultiplier, forwardMovementFactor);
        playerMovement.movementSpeedMultiplier *= multiplier;

    }
}

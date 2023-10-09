using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerJumping : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float jumpPressBufferTime = .05f;
    [SerializeField] float jumpGroundGraceTime = .2f;

    PlayerMovement playerMovement;

    bool tryingToJump;
    float lastJumpPressTime;
    float lastGroundedTime; 

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
    }

    void OnEnable()
    {
        playerMovement.OnBeforeMove += OnBeforeMove; 
        playerMovement.OnGroundStateChange += OnGroundStateChange;
    }

    void OnDisable()
    {
        playerMovement.OnBeforeMove -= OnBeforeMove;
        playerMovement.OnGroundStateChange -= OnGroundStateChange;
    }
    void OnJump()
    {
        tryingToJump = true;
        lastJumpPressTime = Time.time; 
    }

    void OnBeforeMove()
    {
        bool wasTryingToJump = Time.time - lastJumpPressTime < jumpPressBufferTime;
        bool wasGrounded = Time.time -lastGroundedTime < jumpGroundGraceTime;

        bool isOrWasTryingToJump = tryingToJump || (wasTryingToJump && playerMovement.IsGrounded);
        bool isOrWasGrounded = playerMovement.IsGrounded || wasGrounded;

        if (isOrWasTryingToJump && isOrWasGrounded)
        {
            playerMovement.velocity.y += jumpSpeed; 
        }
        tryingToJump = false;
    }

    void OnGroundStateChange(bool isGrounded)
    {
        if (!isGrounded) lastGroundedTime = Time.time; 
    }

}

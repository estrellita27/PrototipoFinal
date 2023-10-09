using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCrouching : MonoBehaviour
{
    [SerializeField] float crouchHeight = 1f;
    [SerializeField] float crouchTransitionSpeed = 10f;
    [SerializeField] float crouchSpeedMultiplier = .5f;




    PlayerMovement playerMovement;
    PlayerInput playerInput;
    InputAction crouchAction;

    Vector3 initialCameraPosition;
    float currentHeight;
    float standingHeight;

    bool IsCrouching => standingHeight - currentHeight > .1f; 

    void Awake ()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        crouchAction = playerInput.actions["crouch"]; 
    }

    void Start()
    {
        initialCameraPosition = playerMovement.cameraTransform.localPosition; 
        standingHeight = currentHeight = playerMovement.Height;
    }

    void OnEnable() => playerMovement.OnBeforeMove += OnBeforeMove;
    void OnDisable() => playerMovement.OnBeforeMove -= OnBeforeMove;

    void OnBeforeMove()
    {
        var isTryingToCrouch = crouchAction.ReadValue<float> () > 0;

        var heightTarget = isTryingToCrouch ? crouchHeight : standingHeight;

        if (IsCrouching && !isTryingToCrouch)
        {
            var castOrigin = transform.position + new Vector3(0, currentHeight / 2, 0); 
            if(Physics.Raycast(castOrigin, Vector3.up, out RaycastHit hit, 0.2f))
            {
                var distanceToCeiling = hit.point.y - castOrigin.y;
                heightTarget = Mathf.Max
                    (
                        currentHeight + distanceToCeiling - 0.1f,
                        crouchHeight
                    ); 
            }
        }


        if (!Mathf.Approximately( heightTarget, currentHeight ))
        {
            var crouchDelta = Time.deltaTime * crouchTransitionSpeed;
            currentHeight = Mathf.Lerp(currentHeight, heightTarget, crouchDelta);

            var halfHeightDifference = new Vector3(0, (standingHeight - heightTarget) / 2, 0);
            var newCameraPosition = initialCameraPosition - halfHeightDifference;

            playerMovement.cameraTransform.localPosition = newCameraPosition;
            playerMovement.Height = currentHeight;
        }
        if (IsCrouching)
        {
            playerMovement.movementSpeedMultiplier *= crouchSpeedMultiplier; 
        }
        
    }


}

using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float mass = 1f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Transform cameraTransform;

    CharacterController controller;
    Vector3 velocity; 
    Vector2 look; 

    void Awake()
    {
        controller = GetComponent<CharacterController>(); 
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       UpdateGravity(); 
       UpdateLook();
       UpdateMovement(); 
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y; 
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += cameraTransform.forward * y; 
        input += cameraTransform.forward * x;
        input += Vector3.ClampMagnitude(input, 1f);
        
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed; 
        }

       
       controller.Move((input * movementSpeed + velocity) * Time.deltaTime);


    }
    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

}






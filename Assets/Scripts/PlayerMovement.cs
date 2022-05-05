using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Heavy help from https://www.youtube.com/watch?v=4HpC--2iowE&t=900s

    public CharacterController controller;
    public Transform cameraTransform;
    public float gravity;
    public float movementSpeed;
    public float turnTime;
    public float sprintSpeedMultiplier;
    public float jumpHeight;

    private bool sprinting;
    private float currentMovementSpeed;
    private float currentVelocity;

    void Start()
    {
        currentMovementSpeed = movementSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !sprinting)
        {
            currentMovementSpeed *= sprintSpeedMultiplier;
            sprinting = true;
        }
        else
        {
            currentMovementSpeed = movementSpeed;
            sprinting = false;
        }

        float jumpVelocity = 0f;
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpVelocity = jumpHeight * -gravity;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

        if (direction != Vector3.zero)
        {
            //Finds the vector between x and z (Atan2), turns it into degrees and then add camera rotation to move with the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float playerAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, playerAngle, 0f);

            //Turns rotation into x and z
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Time.deltaTime * currentMovementSpeed);
        }

        //Apply gravity
        controller.Move(Vector3.up * (gravity + jumpVelocity) * Time.deltaTime);
    }
}

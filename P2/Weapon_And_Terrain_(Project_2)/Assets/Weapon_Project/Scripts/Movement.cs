using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool sprinting;
    public float vertVelocity;
    public int jumpCounter;
    public int jumpAddup;


    public Vector3 movement = Vector3.zero;

    public void Update()
    {
        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        CharacterController charMovement = GetComponent<CharacterController>();
        charMovement.Move(movement * Time.deltaTime);
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);

        if (sprinting == false) {
            movement *= gameOptions.walkingSpeed;
        }

        else if (sprinting == true) {
            movement *= gameOptions.sprintingSpeed;
        }

        if (Input.GetButton("Sprint"))  {
            sprinting = true;
        }
        else    {
            sprinting = false;
        }

        if (charMovement.isGrounded) {
            jumpCounter = 0;
            vertVelocity = -gameOptions.gravity * Time.deltaTime;
        } else
        {
            vertVelocity -= gameOptions.gravity * Time.deltaTime;
            movement = new Vector3(movement.x, vertVelocity, movement.z);
        }

        if(jumpCounter < gameOptions.maxJumps)   {
        if (Input.GetButtonDown("Jump"))
        {
            vertVelocity = gameOptions.jumpForce;
                jumpCounter += jumpAddup;
            }
            else
            {

            }
        }
    }
}

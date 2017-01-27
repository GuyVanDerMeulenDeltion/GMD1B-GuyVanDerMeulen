using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool sprinting;

    public float vertVelocity;

    private int zero = 0;

    public int jumpCounter;
    public int jumpAddup;


    public Vector3 movement = Vector3.zero;

    public void Update()
    {
        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        //Gets the charactercontroller component from the player.
        CharacterController charMovement = GetComponent<CharacterController>();

        //The set speed of your character walking.
        charMovement.Move(movement * Time.deltaTime);
        //The direction your character is walking at by the use of your Mouse.
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);

        //Makes the walkingspeed equal to the regular walking speed float.
        if (sprinting == false)
        {
            movement *= gameOptions.walkingSpeed;
        }

        //Makes the walkingspeed equal to the sprinting float.
        else if (sprinting == true)
        {
            movement *= gameOptions.sprintingSpeed;
        }

        //Checks if the Sprint button is pressed, if so it activates a boolean which makes your character sprint.
        if (Input.GetButton("Sprint"))
        {
            sprinting = true;
        }
        else    {
            sprinting = false;
        }

        //Checks if your character is on the ground.
        if (charMovement.isGrounded)
        {
            //Resets your jumpcounter
            jumpCounter = zero;
            //Places a small amount of pressure on your character so it stays on the ground.
            vertVelocity = -gameOptions.gravity * Time.deltaTime;
        } else
        {
            //The falling speed if your midair.
            vertVelocity -= gameOptions.gravity * Time.deltaTime;
            movement = new Vector3(movement.x, vertVelocity, movement.z);
        }

        //Checks the amount of jumps you have used.
        if(jumpCounter < gameOptions.maxJumps)
        {

        //This checks if the player is jumping, and lets it jump.
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

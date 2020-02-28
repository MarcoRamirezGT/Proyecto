using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 playerInput;
    public CharacterController player;
    public float playerSpeed;
    public float gravity;
    public float fallVelocity;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float horizontalMove;
    public float verticalMove;
    public float jumpForce;
    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = playerSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // horizontalMove = Input.GetAxis("Horizontal");
        // verticalMove = Input.GetAxis("Vertical");

        //  playerInput = new Vector3(horizontalMove, 0, verticalMove);
        // playerInput = Vector3.ClampMagnitude(playerInput, 1);

       CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;
        player.transform.LookAt(player.transform.position + movePlayer);
       

        SetGravity();

        PlayerSkills();


       player.Move(movePlayer * Time.deltaTime);
      //  Debug.Log(player.isGrounded);
    }
    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }
    public void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
    public void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;

        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;

        }
    }
}

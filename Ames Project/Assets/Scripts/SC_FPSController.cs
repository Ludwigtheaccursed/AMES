using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float gravDefault;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public PhysicsMaterial physmat;

    CharacterController characterController;
    Volume blurFX;

   public  Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public float maxDashTime = 3f;
    float dashTime;
    public float dashTimed = 0.1f;
    public float dashCoolDown = 0.3f;
    [HideInInspector]
   public float dashCoolDownTimer;
    public bool grounded;
    public Image dashMeter;


   
    public bool canMove = true;
    public float respawnY = -20;
    public PauseMenu PM;

    void Start()
    {
        dashTime = maxDashTime;
        characterController = GetComponent<CharacterController>();
        blurFX = GetComponentInChildren<Volume>();
        blurFX.enabled = false;
       PM = GameObject.Find("Pause Menu").GetComponent<PauseMenu>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gravDefault = gravity;
    }

    void Update()
    {
        if (transform.position.y < respawnY)
        {
            PM.Reload();
        }
        dashCoolDownTimer += Time.deltaTime;
        dashMeter.fillAmount = dashCoolDownTimer / dashCoolDown;
        grounded = characterController.isGrounded;
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            Debug.Log("JumpSuccessfullyCalled");
            moveDirection.y = jumpSpeed;
            Debug.Log("JumpSuccessfullyCalled2");
        }
      else  if (Input.GetButton("dash") && dashTime >= maxDashTime && canMove && dashCoolDown <= dashCoolDownTimer)
        {

            dashTime = 0f;
            dashCoolDownTimer = 0f;
            
        }
       else if (dashTime < maxDashTime)
        {
            Debug.Log("mash");
            canMove = false;
            blurFX.enabled = true;
            gravity = gravity * 1.2f;
            moveDirection = (forward) * 100;
            dashTime += dashTimed;
        }
       
        else
        {
            blurFX.enabled = false;

            canMove = true;
            gravity = gravDefault;
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
       // if (canMove)
       characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }


    }
    
}
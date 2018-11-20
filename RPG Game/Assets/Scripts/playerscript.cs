using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour {
    //vars
    public float speed = 6.0f;
    public float runSpeed = 12.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float turnSpeed = 45;
    //bits
    public Animation walk;
    public Camera mycamera;
    private Rigidbody mybody;
    private CharacterController controller;
    
    //controls
    private Vector3 moveDirection = Vector3.zero;
    private float forwardMotion;
    private float lrMotion;
    private float verticalCameraMotion;
    private float horizontalCameraMotion;
    private float aimingMotion;
    private bool isRunning = false;
    Quaternion rotator;
    //functions
    void Start()
    {
        // controller = GetComponent<CharacterController>();
        rotator = transform.rotation;
        mybody = GetComponent<Rigidbody>();
        walk = GetComponent<Animation>();
        walk.wrapMode = WrapMode.Loop;
        foreach (AnimationState state in walk)
    {
        state.speed = 2F;
    }
    }

    void Update()
    {
        InputManager();
        Turn();
     //   if (controller.isGrounded)
     //   {
     //       // We are grounded, so recalculate
     //       // move direction directly from axes

     //       moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
     //       moveDirection = transform.TransformDirection(moveDirection);
     //       moveDirection = moveDirection * speed;
     //       //if (Input.GetKeyDown(KeyCode.D))
     //       //{
     //       //    transform.rotation = Quaternion.Euler(0,90,0);
     //       //}
    if (Input.GetKeyDown(KeyCode.A))
    {
            //transform.rotation = Quaternion.Euler(0, 270, 0);
           // walk.CrossFade("run");
    }
     //       //if (Input.GetKeyDown(KeyCode.W))
     //       //{
     //       //    transform.rotation = Quaternion.Euler(0, 0, 0);
     //       //}
     //       //if (Input.GetKeyDown(KeyCode.S))
     //       //{
     //       //    transform.rotation = Quaternion.Euler(0, 180, 0);
     //       //}
     //       transform.rotation = Quaternion.AngleAxis(Time.deltaTime,Vector3.up);//Euler(moveDirection*90);
     //       walk.Play();
    if (Input.GetButton("Jump"))
          {
             Debug.LogError("WILLIAM DO STUFF");
     //           moveDirection.y = jumpSpeed;
          }
     //   }

     //   // Apply gravity
     //moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

     //   // Move the controller
     //   controller.Move(moveDirection * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //physics
        Move();
    }
    private void InputManager()
    {
        forwardMotion = Input.GetAxis("Vertical");
        lrMotion = Input.GetAxis("Horizontal");
        aimingMotion = Input.GetAxis("Mouse ScrollWheel");
        verticalCameraMotion = Input.GetAxis("Mouse X");
        horizontalCameraMotion = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.E))
        {
            isRunning = true;
        } else
        {
            isRunning = false;
        }
        //lets be organized here. functions for everything.
    }
    private void Move()
    {
        //move and stuf
        mybody.velocity = gameObject.transform.forward * forwardMotion * speed;
        if (isRunning)
        {
            //move faster, change animation.
            mybody.velocity = Vector3.forward * forwardMotion * runSpeed;
        } 
        
    }
    private void Jump()
    {
        //boing boing m'f'cker
    }
    private void Attack()
    {
        //hit things
    }
    private void Turn()
    {
       rotator *= Quaternion.AngleAxis(lrMotion * turnSpeed * Time.deltaTime, Vector3.up);
        transform.rotation = rotator;
        //rotate character
    }
    private void SummonBlock()
    {
        //I was thinking we could have some physicsy fun by throwing things in the air akin to cryonis in botw.
    }
}
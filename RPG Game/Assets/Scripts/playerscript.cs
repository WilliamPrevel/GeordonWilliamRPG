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
    public int HP = 100;
    public int MAXHP = 100;
    public int MP = 0;
    public int MAXMP = 0;
    public float attackDamage = 10;
    public float armor = 0;
    public bool covfefe;
    public int exp = 0;
    public int LV = 1;
    public int MAXLV = 1;
    public float weaponLength = 0.5f;
    //bits
    public Animator anim;
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
    RaycastHit hit;
    //functions
    void Start()
    {
        // controller = GetComponent<CharacterController>();
        rotator = transform.rotation;
        mybody = GetComponentInChildren<Rigidbody>();
       // walk = GetComponent<Animation>();
        //  walk.wrapMode = WrapMode.Loop;
        //    foreach (AnimationState state in walk)
        //{
        //    state.speed = 2F;
        //}
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
        if (Input.GetKey(KeyCode.D))
        {
            //anim.SetBool("isWalking", true);  //walk.Play("run");//       //    transform.rotation = Quaternion.Euler(0,90,0);
            if (isRunning)
            {

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
          //  anim.SetBool("isWalking", true);  //transform.rotation = Quaternion.Euler(0, 270, 0);
                                              //walk.Play("run");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
           // anim.SetBool("isWalking", true);//walk.Play("run"); //       //    transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
           //walk.Play("run");  //       //    transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            //walk.Play("idle");
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        //       transform.rotation = Quaternion.AngleAxis(Time.deltaTime,Vector3.up);//Euler(moveDirection*90);
        //       walk.Play();
        //its actually attacking
        if (Input.GetButtonDown("Jump"))
        {
            Debug.LogError("WILLIAM DO STUFF");
            anim.SetBool("bIsAttacking", true);
            Invoke("DoDamage", .50f);
            Invoke("FinishAttack", .80f);
            //DoDamage();
            // moveDirection.y = jumpSpeed;
        }

        // Apply gravity
      //  moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        // controller.Move(moveDirection * Time.deltaTime);
    }
    private void DoDamage()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if(hit.transform.gameObject.tag == "Enemy")
            {
              //  hit.transform.gameObject.getComponent<Enemy>;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
    private void FinishAttack()
    {
        anim.SetBool("bIsAttacking", false);
    }
    private void FixedUpdate()
    {
        //physics
        Move();
        //mycamera.velocity = (5, 5, 5);
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
            anim.SetBool("isRunning", true);
        } else
        {
            isRunning = false;
            anim.SetBool("isRunning", false);
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
            mybody.velocity = gameObject.transform.forward * forwardMotion * runSpeed;
        } 
        
    }
    private void Jump()
    {
        //boing boing m'f'cker
    }
    private void Attack()
    {
        //hit things
        //walk.Play("attack1");
    }
    private void Turn()
    {
       // if (isRunning == false)
       // {
            rotator *= Quaternion.AngleAxis(lrMotion * turnSpeed * Time.deltaTime, Vector3.up);
            transform.rotation = rotator;
       // }
        //rotate character
    }
    private void SummonBlock()
    {
        //I was thinking we could have some physicsy fun by throwing things in the air akin to cryonis in botw.
    }
}
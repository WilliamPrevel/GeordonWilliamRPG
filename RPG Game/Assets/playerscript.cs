using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour {
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Animation walk;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall downz
        walk = GetComponent<Animation>();
    foreach (AnimationState state in walk)
    {
        state.speed = 0.5F;
    }
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    transform.rotation = Quaternion.Euler(0,90,0);
            //}
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    transform.rotation = Quaternion.Euler(0, 270, 0);
            //}
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, 0);
            //}
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    transform.rotation = Quaternion.Euler(0, 180, 0);
            //}
            transform.rotation = Quaternion.AngleAxis(Time.deltaTime,Vector3.up);//Euler(moveDirection*90);
            walk.Play();
            if (Input.GetButton("Jump"))
            {
                Debug.LogError("WILLIAM");
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
     moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyScript : Enemy {
    //work in progress
    private float random;
    Vector3 destination = new Vector3(0, 0, 0);
    public int roamdistance = 30;
    public int roamTime = 10;
    private int roam = 10;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    // Use this for initialization
    void Start()
    {
        roam = roamTime;
        mybody = GetComponentInChildren<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        random = Random.Range(-10f, 10.0f);
        roamTime--;
        if (roamTime <= 0)
        {
            roamTime = roam;
            Roam();
        }
        if (isGrounded)
    {

        mybody.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
    }
    void Update()
    {
        if (EnemyType == "SpiderLady")
        {
            anim.SetBool("isAttacking", false);
        }
        if (HP <= 0)
        {
            if (EnemyType == "SpiderLady")
            {
                anim.SetBool("isDead", true);
            }
            Invoke("Dead", 5);
        }

    }
    private void Roam()
    {
        Vector2 getdestination = Random.insideUnitCircle * roamdistance;
        destination = new Vector3(getdestination.x, 0, getdestination.y);
        if (EnemyType == "SpiderLady")
        {
            anim.SetBool("isJumping", true);
        }
        Quaternion restrictor = Quaternion.Euler(0, 1, 0);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination), turnSpeed) * restrictor;
        destination = destination - (transform.position);
        mybody.velocity = gameObject.transform.forward * speed;
    }
        void OnCollisionStay()
    {
        isGrounded = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    protected Rigidbody mybody;
    Quaternion rotator;
    Quaternion restrictor = Quaternion.Euler(0, 1, 0);
    public string EnemyType;
    public float speed = 6.0f;
    public float runSpeed = 12.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float turnSpeed = 1.1f;
    public float sightDistance = 10;
    public int HP = 50;
    public int MAXHP = 50;
    public int MP = 0;
    public int MAXMP = 0;
    public float attackDamage = 20;
    public float armor = 0;
    public bool covfefe;
    public int exp = 0;
    public int LV = 1;
    public int MAXLV = 1;
   
    private bool isAttacking;
    void Start()
    {
        rotator = transform.rotation;
        mybody = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {

        if (Vector3.Distance(player.position, this.transform.position) < sightDistance)

        {
            if (EnemyType == "SpiderLady")
            {
                anim.SetBool("isAttacking", true);
            }
            Vector3 direction = player.position - this.transform.position;

           
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,

            Quaternion.LookRotation(direction)*restrictor, turnSpeed);

            if (direction.magnitude > 5)
            {

                this.transform.Translate(0, 0, 0.05f);

            }

        }
        else if (EnemyType == "SpiderLady")
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
    private void Dead(){
        gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform hats;
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
    public float weaponLength = 10;
    public int attackDelay = 10;
    public int HP = 50;
    public int MAXHP = 50;
    public int MP = 0;
    public int MAXMP = 0;
    public int attackDamage = 20;
    public float armor = 0;
    public bool covfefe;
    public int exp = 0;
    public int LV = 1;
    public int MAXLV = 1;
    RaycastHit hit;
    private bool droppedloot = false;
    public GameObject hitplayer;
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
            Invoke("Attack", attackDelay);


            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,

            Quaternion.LookRotation(direction) * restrictor, turnSpeed);

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
    private void Dead() {
        if (droppedloot == false)
        {
            DropLoot();
        }
        //WILL UPDATE THIS TO RETURN TO OBJECT POOL
        gameObject.SetActive(false);
    }

    private void DoDamage()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit");
            if (hit.transform.gameObject.tag == "Player")
            {
                hitplayer = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<playerscript>();
                hitplayer.GetComponent<playerscript>().HP -= attackDamage;
                Debug.Log("Hit Player");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit Player");
        }
    }

    private void FinishAttack()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    private void Attack()
    {
        //hit things
        isAttacking = true;
        Invoke("DoDamage", .50f);
        Invoke("FinishAttack", .80f);
    }
    private void DropLoot()
    {
        Instantiate(hats,this.gameObject.transform.position, Quaternion.identity);
        droppedloot = true;
    //summon exp
    //we will worry about changing weapons and other items in polish
    //set exphats player object to this scripts player object!
    //set exphat's exp value to this things exp value!
}
}

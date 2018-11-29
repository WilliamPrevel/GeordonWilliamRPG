using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerInfo
{
    public int HP;
    public int MP;
    public int MPDrain;
    public float Armor;
    public int exp;
    public int LV;
    public int attackDamage;
}

public class playerscript : MonoBehaviour
{

    public PlayerInfo PlayerStatInfo;
    //vars
    public float speed = 6.0f;
    public float runSpeed = 12.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float turnSpeed = 45;
    //public int HP = 100;
    public int MAXHP = 100;
    //public int MP = 100;
    public int MAXMP = 100;
    //public int attackDamage = 10;
    public int MPDrain = 10;
    public float armor = 0;
    public bool covfefe;
    //public int exp = 0;
    public int LV;
    public int MAXLV = 100;
    public float weaponLength = 0.5f;
    private bool isattacking;
    //bits
    public Animator anim;
    public Camera mycamera;
    private GameObject hitenemy;
    private Rigidbody mybody;
    private CharacterController controller;
    public Weapon currentWeapon;
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
   //InputManager putter = InputManager.GetInstance();
   
    //functions
    void Start()
    {
        forwardMotion = 0;
        rotator = transform.rotation;
        mybody = GetComponentInChildren<Rigidbody>();
        currentWeapon = GetComponentInChildren<Sword>();
        InputManager.MoveForward += Move;
        InputManager.SpecialAttack += SAttack;
        InputManager.SwitchWeapon += ChangeWeapon;
        LV = PlayerStatInfo.LV;
    }

    private void OnDisable()
    {
        //do this for all
        InputManager.MoveForward -= Move;
    }
    void Update()
    {
        EventManager();
        Turn();
        statCheck();
        
    }

    private void statCheck()
    {
        if(PlayerStatInfo.exp > PlayerStatInfo.LV * 100 && PlayerStatInfo.LV < MAXLV)
        {
            Levelup();
        }
        if(PlayerStatInfo.HP > MAXHP)
        {
            /*
             * Player.HP -> Player.PlayerStatInfo.HP
             * 
             * HP -> PlayerStatInfo.HP
             */
            PlayerStatInfo.HP = MAXHP;
        }
        if (PlayerStatInfo.MP > MAXMP)
        {
            //MP = MAXMP;
            PlayerStatInfo.MP = MAXMP;
        }
        if (PlayerStatInfo.HP <= 0)
        {
            anim.SetBool("isDead", true);
            Invoke("Dead", 5);
        }
    }

    private void FixedUpdate()
    {
        //physics
        //Move();
    }

    //private void DoDamage()
    //{
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
    //        Debug.Log("Hit");
    //        if(hit.transform.gameObject.tag == "Enemy")
    //        {
    //            hitenemy = hit.transform.gameObject;
    //            hit.transform.gameObject.GetComponent<Enemy>();
    //            hitenemy.GetComponent<Enemy>().HP -= attackDamage;
    //            Debug.Log("Hit Enemy");
    //        }
    //    }
    //    else
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    //        Debug.Log("Did not Hit");
    //    }
    //}
    //private void DoMoreDamage()
    //{
        
    //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
    //        {
    //            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
    //            Debug.Log("Hit");
    //        MP -= MPDrain;
    //        if (hit.transform.gameObject.tag == "Enemy")
    //            {
    //                hitenemy = hit.transform.gameObject;
    //                hit.transform.gameObject.GetComponent<Enemy>();
    //                hitenemy.GetComponent<Enemy>().HP -= attackDamage * 2;
                    
    //                Debug.Log("Hit Enemy");
    //            }
    //        }
    //        else
    //        {
    //            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    //            Debug.Log("Did not Hit");
    //        }
        
    //}

    private void FinishAttack()
    {
        anim.SetBool("bIsAttacking", false);
        isattacking = false;
    }

    private void EventManager()
    {
        forwardMotion = Input.GetAxis("Vertical");
        lrMotion = Input.GetAxis("Horizontal");
        aimingMotion = Input.GetAxis("Mouse ScrollWheel");
        verticalCameraMotion = Input.GetAxis("Mouse Y");
        horizontalCameraMotion = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
        {
            //turn around
            rotator *= Quaternion.AngleAxis(180, Vector3.up);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (isattacking == false)
                Attack();
        }
        //if (putter.specialattack)
        //{
        //    if (isattacking == false)
        //    {
        //        if (MP >= MPDrain)
        //        {

        //            SAttack();
        //        }
        //        else
        //        {
        //            Attack();
        //        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isRunning = true;
            anim.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            anim.SetBool("isRunning", false);
        }
    }
    private void Move()
    {
        //move and stuf
        if (isattacking == false)
        {
            mybody.velocity = gameObject.transform.forward * Mathf.Abs(forwardMotion) * speed;
                if (isRunning)
                {
                    //move faster, change animation.
                    mybody.velocity = gameObject.transform.forward * forwardMotion * runSpeed;
                }
        }
    }
    private void Jump()
    {
        //boing boing m'f'cker
    }
    private void Attack()
    {
        //hit things
        isattacking = true;
        anim.SetBool("bIsAttacking", true);
        currentWeapon.Invoke("DoDamage", .50f);
        Invoke("FinishAttack", .80f);
    }
    private void SAttack()
    {
        //hit things
        isattacking = true;
        anim.SetBool("bIsAttacking", true);
        currentWeapon.Invoke("Shoot", .50f);
        Invoke("FinishAttack", .80f);
    }

    private void Turn()
    {
        //rotate character
            rotator *= Quaternion.AngleAxis(lrMotion * turnSpeed * Time.deltaTime, Vector3.up);
            transform.rotation = rotator;
    }

    private void Levelup()
    {
        speed++;
        runSpeed++;
        jumpSpeed++;
        MAXHP+= 10;
        MAXMP+=10;
        PlayerStatInfo.attackDamage++;
        covfefe = true;
        PlayerStatInfo.exp = 0;
        PlayerStatInfo.LV++;
    }

    private void SummonBlock()
    {
        //I was thinking we could have some physicsy fun by throwing things in the air akin to cryonis in botw.
    }

    private void Dead()
    {

    }
    public void SetupPlayer (PlayerInfo PlayerInformation)
    {
        PlayerStatInfo = PlayerInformation;

        PlayerStatInfo.HP = PlayerInformation.HP;
        PlayerStatInfo.MP = PlayerInformation.MP;
        PlayerStatInfo.exp = PlayerInformation.exp;
        PlayerStatInfo.LV = PlayerInformation.LV;
        PlayerStatInfo.attackDamage = PlayerInformation.attackDamage;
    }

    private void ChangeWeapon()
    {
        if(currentWeapon.gameObject.tag == "Sword")
        {
            currentWeapon.transform.localScale = new Vector3(0, 0, 0);
            currentWeapon = GetComponentInChildren<RangedWeapon>();
            currentWeapon.transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            currentWeapon.transform.localScale = new Vector3(0, 0, 0);
            currentWeapon = GetComponentInChildren<Sword>();
            currentWeapon.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
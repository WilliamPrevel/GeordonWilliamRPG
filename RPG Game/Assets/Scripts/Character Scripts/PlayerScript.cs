using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : CharacterScript
{
    GameManager theBoss;
    public GameObject arrow;
    public int currentWeaponNumber;
    public int currentWeaponSlot = 0;
    public int currentArmorNumber;
    public int currentArmorSlot = 0;
    //go forward
    public float VerticalAxis;
    //turn player
    public float HorizontalAxis;
    protected Camera myCamera;
    protected bool isRunning;
    public int hasZPM = 0;
    override public void Start()
    {
        //go forward
        base.Start();
        InputManager.MoveForward += Move;
        InputManager.MoveBack += MoveBackwards;
        InputManager.Turn += Turn;
        InputManager.Idle += Idle;
        InputManager.Attack += Attack;
        InputManager.SpecialAttack += SpecialAttack;
        InputManager.SwitchWeapon += ChangeWeapon;
        myCamera = gameObject.GetComponentInChildren<Camera>();
        //this is a player.
        myStats.isPlayer = true;
        //start playing when a player is spawned
        GameManager.CurrentState = GameManager.GameState.Playing;
    }

    private void OnDisable()
    {
        InputManager.MoveForward -= Move;
        InputManager.MoveBack -= MoveBackwards;
        InputManager.Turn -= Turn;
        InputManager.Idle -= Idle;
        InputManager.Attack -= Attack;
        InputManager.SwitchWeapon -= ChangeWeapon;
    }

    override protected void Update()
    {
        base.Update();
        currentWeaponNumber = GameManager.Inventory.Count;
        currentArmorNumber = GameManager.Inventory2.Count;
        statCheck();
        VerticalAxis = Input.GetAxis("Vertical");
        //turn player
        HorizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public void SetupPlayer(SavedStats LoadedStats)
    {
        myStats.Health = LoadedStats.Health;
        myStats.Mana = LoadedStats.Mana;
        myStats.Experience = LoadedStats.Experience;
        myStats.Level = LoadedStats.Level;
        myStats.MaxHealth = LoadedStats.MaxHealth;
        myStats.MaxMana = LoadedStats.MaxMana;
    }
    override protected void Move()
    {
        if (isAttacking == false)
        {
            if (isRunning)
            {
                myBody.velocity = (gameObject.transform.forward * myStats.RunSpeed);
                myAnimator.SetBool("isRunning", true);
            }
            else
            {
                myBody.velocity = (gameObject.transform.forward * myStats.WalkSpeed);
                Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.forward * myStats.WalkSpeed), Color.green, 2, false);
                myAnimator.SetBool("isWalking", true);
            }
        }
    }
    void MoveBackwards()
    {
        if (isAttacking == false)
        {
            if (isRunning)
            {
                myBody.velocity = (gameObject.transform.forward * myStats.RunSpeed / 2);
                myAnimator.SetBool("isRunning", true);
            }
            else
            {
                myBody.velocity = (gameObject.transform.forward * myStats.WalkSpeed / 2);
                myAnimator.SetBool("isWalking", true);
            }
        }
    }
    protected override void Idle()
    {
        //base.Idle();
        myAnimator.SetBool("isWalking", false);
        myAnimator.SetBool("isRunning", false);
    }

    override protected void Turn()
    {
        gameObject.transform.Rotate(0, HorizontalAxis * myStats.TurnSpeed * Time.deltaTime, 0);
        //Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.forward * myStats.WalkSpeed), Color.blue, 2, false);

    }

    public void SpecialAttack()
    {
        if (myStats.Mana >= 5)
        {
            myStats.Mana -= 5;
            Instantiate(arrow, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    private void ChangeWeapon()
    {

        if (currentWeaponNumber > 0)
        {
            Debug.Log(GameManager.Inventory[currentWeaponSlot].weaponName);
            // currentWeapon.SetActive(false);
            if (currentWeaponSlot < currentWeaponNumber - 1)
            {
                currentWeaponSlot++;
            }
            else
            {
                currentWeaponSlot = 0;
            }
            currentWeapon.GetComponent<Weapon>().myStats = GameManager.Inventory[currentWeaponSlot];
            currentWeapon.GetComponent<Weapon>().isHeld = true;
            // currentWeapon.SetActive(true);
            Debug.Log(GameManager.Inventory[currentWeaponSlot].weaponName);
        }
        else
        {
            Debug.Log("You are Unarmed!");
        }
    }

}

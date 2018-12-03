﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : CharacterScript {
    GameManager theBoss;
    public int currentWeaponNumber;
    public int currentWeaponSlot = 0;
    //go forward
    float VerticalAxis;
    //turn player
    float HorizontalAxis;
   protected Camera myCamera;
    protected bool isRunning;
    override public void Start () {
        //go forward
        base.Start();
        InputManager.MoveForward += Move;
        InputManager.Turn += Turn;
        InputManager.Idle += Idle;
        InputManager.Attack += Attack;
        InputManager.SwitchWeapon += ChangeWeapon;
        //currentWeapon = GameObject.Find("Weapon");
        //InputManager.SwitchWeapon += ChangeWeapon;
        myCamera = gameObject.GetComponentInChildren<Camera>();
        //this is a player.
        myStats.isPlayer = true;
        //start playing when a player is spawned
        GameManager.CurrentState = GameManager.GameState.Playing;
    }

    private void OnDisable()
    {
        InputManager.MoveForward -= Move;
        InputManager.Turn -= Turn;
        InputManager.Idle -= Idle;
        InputManager.Attack -= Attack;
        InputManager.SwitchWeapon -= ChangeWeapon;
    }

   override protected void Update () {
        base.Update();
        currentWeaponNumber = GameManager.Inventory.Count;
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
        //do a raycast to see if there is a wall immediately in front of player!
        //move forward.
        // gameObject.transform.Translate(Vector3.forward * VerticalAxis * myStats.WalkSpeed);
        //for physics
        if (isAttacking == false)
        {
            if (isRunning)
            {
                myBody.velocity = (gameObject.transform.forward * VerticalAxis * myStats.RunSpeed);
                myAnimator.SetBool("isRunning", true);
            }
            else
            {
                myBody.velocity = (gameObject.transform.forward * VerticalAxis * myStats.WalkSpeed);
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
    }

    private void ChangeWeapon()
    {
        Debug.Log(GameManager.Inventory[currentWeaponSlot].weaponName);
        if (currentWeaponNumber > 0)
        {
            currentWeapon.SetActive(false);
            if (currentWeaponSlot < currentWeaponNumber-1)
            {
                currentWeaponSlot++;
            }
            else
            {
                currentWeaponSlot = 0;
            }
            currentWeapon.GetComponent<Weapon>().myStats = GameManager.Inventory[currentWeaponSlot];
            currentWeapon.GetComponent<Weapon>().isHeld = true;
            currentWeapon.SetActive(true);
            Debug.Log(GameManager.Inventory[currentWeaponSlot].weaponName);
        } else
        {
            Debug.Log("You are Unarmed!");
        }
    }
   
}

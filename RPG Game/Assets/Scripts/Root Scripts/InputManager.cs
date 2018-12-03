﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

   // private Vector3 moveDirection = Vector3.zero;
   // private static float forwardMotion;
    private static float lrMotion;
    private static float verticalCameraMotion;
    private static float horizontalCameraMotion;
    private static float aimingMotion;

    public delegate void MoveAction();
    public static event MoveAction MoveForward;
   // public static event MoveAction MoveBack;
    public static event MoveAction Turn;
   // public static event MoveAction Run;
    public static event MoveAction Idle;

    public delegate void AttackAction();
    public static event AttackAction Attack;
    public static event AttackAction SpecialAttack;

    public delegate void OtherAction();
    public static event OtherAction SwitchWeapon;

    public static InputManager instance;
    void Start()
    {
        //singleton
        if (instance == null) { instance = this; }
        else { Destroy(this); }
        //no kill
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(true)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
                if(GameManager.CurrentState == GameManager.GameState.Playing)
            MoveForward();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (GameManager.CurrentState == GameManager.GameState.Playing)
                SpecialAttack();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (GameManager.CurrentState == GameManager.GameState.Playing)
                SwitchWeapon();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (GameManager.CurrentState == GameManager.GameState.Playing)
                Turn();
        }
        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
            Idle();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (GameManager.CurrentState == GameManager.GameState.Playing)
                Attack();
            if (GameManager.CurrentState == GameManager.GameState.Dialogue)
                GameManager.CurrentState = GameManager.GameState.Playing;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (GameManager.CurrentState == GameManager.GameState.Playing)
                SwitchWeapon();
        }
    }
    public static InputManager GetInstance() { return instance; }
}
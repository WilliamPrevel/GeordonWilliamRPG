//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class InputManager2 : MonoBehaviour
//{ 
////public Singleton class InputManager : MonoBehaviour {
//    // public delegate void WDown();
//    // public static event WDown isDown;
//    private Vector3 moveDirection = Vector3.zero;
//    private static float forwardMotion;
//    private static float lrMotion;
//    private static float verticalCameraMotion;
//    private static float horizontalCameraMotion;
//    private static float aimingMotion;
//    private static bool isRunning = false;
//    public static UnityEvent W;
//    public static UnityEvent S;
//    public static UnityEvent A;
//    public static UnityEvent D;
//    public delegate void MoveAction();
//    public static event MoveAction MoveForward;
//    public static event MoveAction MoveBack;
//    public static event MoveAction Turn;
//    public delegate void AttackAction();
//    public static event AttackAction Attack;
//    public static event AttackAction SpecialAttack;
//    public delegate void OtherAction();
//    public static event OtherAction SwitchWeapon;
//    private static InputManager instance;
//    //public InputManager Instance { get { return instance; } }

//    void Start()
//    {
//        if (W == null)
//            W = new UnityEvent();
//       W.AddListener(Ping);
//        if (S == null)
//            S = new UnityEvent();
//        S.AddListener(Ping);

//        if (instance == null) { instance = this; }
//        else { Destroy(this); }

//       // DontDestroyOnLoad(gameObject);
//    }

//    void Update()
//    {
//        forwardMotion = Input.GetAxis("Vertical");
//        lrMotion = Input.GetAxis("Horizontal");
//        aimingMotion = Input.GetAxis("Mouse ScrollWheel");
//        verticalCameraMotion = Input.GetAxis("Mouse Y");
//        horizontalCameraMotion = Input.GetAxis("Mouse X");
//        if (Input.GetKey(KeyCode.W))
//        {
//            MoveForward();
//        }
//        if (Input.GetKey(KeyCode.Q))
//        {
//            SpecialAttack();
//        }
//        if(Input.GetKeyUp(KeyCode.X))
//        {
//            SwitchWeapon();
//        }
//        if (forwardMotion>0 && W != null)//Input.GetKey(KeyCode.W)
//        {
//            W.Invoke();// "getforwardmotion");
//        } else if(forwardMotion<0 && S != null)
//        {
//            S.Invoke();
//        }
//        if (lrMotion > 0 && A != null)//Input.GetKey(KeyCode.W)
//        {
//            A.Invoke();
//        }
//        else if (lrMotion < 0 && D != null)
//        {
//            D.Invoke();
//        }
//    }
//    public float getforwardmotion()
//    {
//        return forwardMotion;
//    }
//    public static InputManager GetInstance() { return instance; }

//    void Ping()
//    {
//      //  Debug.Log("Ping");
//    }
//}
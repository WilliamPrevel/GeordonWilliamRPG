using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMPBar : MonoBehaviour {


    float MP;
    float MAXMP;
    float currentmp;
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MP = player.GetComponentInParent<playerscript>().MP;
        MAXMP = player.GetComponentInParent<playerscript>().MAXMP;
        currentmp = MP / MAXMP;
        gameObject.transform.localScale = new Vector3(currentmp, 1, 1);
       // Debug.Log(currentmp);
    }
}
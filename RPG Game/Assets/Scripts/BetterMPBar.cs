using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMPBar : MonoBehaviour {


    float MP;
    float MAXMP;
    float EXP;
    float MAXEXP;
    float currentmp;
    float currentexp;
    public bool isEXPbar = false;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isEXPbar)
        {
        EXP = player.GetComponentInParent<playerscript>().exp;
        MAXEXP = player.GetComponentInParent<playerscript>().LV*100;
        currentexp = EXP / MAXEXP;
        gameObject.transform.localScale = new Vector3(currentexp, 1, 1);
        } else
        {
        MP = player.GetComponentInParent<playerscript>().MP;
        MAXMP = player.GetComponentInParent<playerscript>().MAXMP;
        currentmp = MP / MAXMP;
        gameObject.transform.localScale = new Vector3(currentmp, 1, 1);
        }// Debug.Log(currentmp);
    }
}
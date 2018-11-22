using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMPBar : MonoBehaviour {


    float MP;
    float MAXMP;
    float currenthp;
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
        currenthp = MP / MAXMP;
        if (MP >= MAXMP || MP <= 0)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(currenthp, 1, 1);
        }
        Debug.Log(currenthp);
    }
}
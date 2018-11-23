using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterHPBar : MonoBehaviour
{

    float HP;
    float MAXHP;
    float currenthp;
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HP = player.GetComponentInParent<playerscript>().HP;
        MAXHP = player.GetComponentInParent<playerscript>().MAXHP;
        currenthp = HP / MAXHP;
        gameObject.transform.localScale = new Vector3(currenthp, 1, 1);
       // Debug.Log(currenthp);
    }
}
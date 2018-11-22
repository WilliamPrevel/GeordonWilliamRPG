using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingBarScript : MonoBehaviour {
        float HP;
        float MAXHP;
        float currenthp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       HP = gameObject.GetComponentInParent<Enemy>().HP;
       MAXHP = gameObject.GetComponentInParent<Enemy>().MAXHP;
       currenthp = HP / MAXHP;
        if (HP >= MAXHP || HP <=0)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
             gameObject.transform.localScale = new Vector3(currenthp, 1, 1);
        }
       // Debug.Log(currenthp);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour {
    public bool activate;
    float HPcheck;
    float MAXHPcheck;
    public Camera mycam;
	void Update () {
        //look at camera code:
    var n = mycam.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(n);
        //you can use this to disable an object
        if (activate)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    //show/hide bar
    HPcheck = gameObject.GetComponentInParent<Enemy>().HP;
    MAXHPcheck = gameObject.GetComponentInParent<Enemy>().MAXHP;
    if (HPcheck >= MAXHPcheck)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    else
    {
      gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
}
}



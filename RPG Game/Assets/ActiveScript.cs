using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour {
    public bool activate;
    float HPcheck;
    float MAXHPcheck;

	void Update () {

        if (activate)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    
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

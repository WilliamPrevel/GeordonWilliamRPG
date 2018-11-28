using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon {
    public GameObject newFireball;

    protected override void Start()
    {
        base.Start();
        newFireball.SetActive(false);
    }
    override protected void DoDamage()
    {

    }
	// Update is called once per frame
	override protected void Shoot () {
       
      GameObject newnew =  Instantiate(newFireball, gameObject.transform.position, Quaternion.identity);
        newnew.SetActive(true);
    }
}

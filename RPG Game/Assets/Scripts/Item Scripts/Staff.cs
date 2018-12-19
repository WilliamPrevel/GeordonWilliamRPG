using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MeleeWeapon {
    public GameObject papercraft;
	// Use this for initialization
	override protected void Start () {
		
	}

    override protected void DoDamage()
    {
        if (Physics.SphereCast(gameObject.GetComponentInParent<Rigidbody>().transform.position, 10, transform.TransformDirection(Vector3.forward), out hit, myStats.weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance * -1, Color.green);
            Debug.Log("Hit");

            if (hit.transform.gameObject.tag == "Enemy")
            {
                hitObject = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<Enemy>();
                hitObject.GetComponent<Enemy>().myStats.Health -= myStats.AttackDamage;
                Debug.Log("Hit Enemy");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
        SpawnSwan();
    }
    public void SpawnSwan()
    {
 if (player.GetComponent<PlayerScript>().myStats.Mana >= 10)
        {
            Instantiate(papercraft, gameObject.transform.position, gameObject.transform.rotation);
            player.GetComponent<PlayerScript>().myStats.Mana -= 10;
        }
    }
    // Update is called once per frame
    override protected void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

   override protected void DoDamage()
    {
        if (Physics.SphereCast(gameObject.GetComponentInParent<Rigidbody>().transform.position, 10, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance * -1, Color.green);
            Debug.Log("Hit");

            if (hit.transform.gameObject.tag == "Enemy")
            {
                hitObject = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<Enemy>();
                hitObject.GetComponent<Enemy>().myStats.Health -= AttackDamage;
                Debug.Log("Hit Enemy");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }
}

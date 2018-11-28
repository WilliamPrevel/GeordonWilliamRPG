using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

   override protected void DoDamage()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit");

            if (hit.transform.gameObject.tag == "Enemy")
            {
                hitObject = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<Enemy>();
                hitObject.GetComponent<Enemy>().HP -= AttackDamage;
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

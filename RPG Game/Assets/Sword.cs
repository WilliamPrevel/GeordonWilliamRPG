using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon {

    override protected void Start()
    {

        if(weaponLength <= 0)
        weaponLength = 5;

        if(AttackDamage <= 0)
        AttackDamage = 10; 

    }

}

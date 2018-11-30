using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon {

    override protected void Start()
    {

        if(myStats.weaponLength <= 0)
            myStats.weaponLength = 5;

        if(myStats.AttackDamage <= 0)
            myStats.AttackDamage = 10; 

    }

}

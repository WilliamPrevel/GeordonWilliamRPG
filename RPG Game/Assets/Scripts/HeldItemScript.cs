using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemScript : MonoBehaviour {
    public string MyName = "Spork";
    public GameObject thePlayer;
    public bool isDefault = false;
    public bool isWeapon = true;
    public bool isArmour = false;
	// Use this for initialization
	void Start () {
        thePlayer = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //for weapons
        if (isWeapon)
        {
            if (isDefault)
            {
                if (GameManager.Inventory.Count == 0)
                {
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                }
            }
            else
            {
                if (GameManager.Inventory.Count > 0)
                {
                    if (thePlayer.GetComponent<PlayerScript>().currentWeapon.GetComponent<Weapon>().myStats.weaponName == MyName)
                    {
                        this.transform.localScale = new Vector3(0.273f, 0.273f, 0.273f);
                    }
                    else
                    {
                        this.transform.localScale = new Vector3(0, 0, 0);
                    }
                }
                else
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                }
            }
        }
        //use this script for armor
        if (isArmour)
        {
            if (GameManager.Inventory2.Count > 0)
            {
                if (thePlayer.GetComponent<PlayerScript>().currentArmour.GetComponent<Armour>().myStats.armourName == MyName)
                {
                    this.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
                }
                else
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                }
            }
            else
            {
                this.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemScript : MonoBehaviour {
    public string MyName = "Spork";
    public GameObject thePlayer;
    public bool isDefault = false;
	// Use this for initialization
	void Start () {
        thePlayer = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

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
        } else
        {
            if (GameManager.Inventory.Count > 0)
            {
                if (thePlayer.GetComponent<PlayerScript>().currentWeapon.GetComponent<Weapon>().myStats.weaponName == MyName)
                {
                    this.transform.localScale = new Vector3(0.273f , 0.273f, 0.273f);
                }
                else
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                }
            } else
                {
                    this.transform.localScale = new Vector3(0,0,0);
                }
            
        }
	}
}

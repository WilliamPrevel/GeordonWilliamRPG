using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStats2
{
    //user seen
    public string armourName = "SPORK";
    public string armourDescription = "Sorta pointy, sorty spoony";
    public int Defence = 5;
    public int durability = 90;
    //back end
    public bool isBreakable = false;
    public int damageTaken = 0;
    public bool isActive = true;
    
}

public abstract class Armour : ItemPickUp {

    public ItemStats2 myStats = new ItemStats2();
    protected RaycastHit hit;
    protected GameObject hitObject;

	// Use this for initialization
	virtual protected void Start () {
		
	}
	
	// Update is called once per frame
	override protected void Update () {
		
	}

    abstract protected void Defense();

    public void setActive()
    {
        if (!myStats.isActive)
        {
            gameObject.SetActive(false);
            myStats.isActive = false;
        } else
        {
            gameObject.SetActive(true);
            myStats.isActive = true;
        }
    }

    protected void TakeDamage()
    {

    }
}

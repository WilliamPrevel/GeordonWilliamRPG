using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStats
{
     public float weaponLength;
    public int AttackDamage;
    public bool isBreakable = false;
    public int durability;
    public int damageTaken;
    public bool isActive = true;
}

public abstract class Weapon : ItemPickUp {

   public ItemStats myStats = new ItemStats();
    protected RaycastHit hit;
    protected GameObject hitObject;

	// Use this for initialization
	virtual protected void Start () {
		
	}
	
	// Update is called once per frame
	override protected void Update () {
		
	}

   protected void Attack()
    {

    }

    abstract protected void DoDamage();

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
    
    protected void Shatter()
    {

    }

    protected void TakeDamage()
    {

    }

    virtual protected void Shoot()
    {

    }
}

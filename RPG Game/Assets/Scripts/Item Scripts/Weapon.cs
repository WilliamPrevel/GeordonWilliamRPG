using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float weaponLength;
    public int AttackDamage;

    public bool isBreakable = false;
    public int durability;
    public int damageTaken;
    public bool isActive = true;
    protected RaycastHit hit;
    protected GameObject hitObject;

	// Use this for initialization
	virtual protected void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

   protected void Attack()
    {

    }

    abstract protected void DoDamage();

    public void setActive()
    {
        if (!isActive)
        {
            gameObject.SetActive(false);
            isActive = false;
        } else
        {
            gameObject.SetActive(true);
            isActive = true;
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

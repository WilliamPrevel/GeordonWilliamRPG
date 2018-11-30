using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//lets you edit in unity
[System.Serializable]
public class CharacterStats
{
    public bool isPlayer;
    public bool isDead;

    public int Health;
    public int MaxHealth;
    public int Mana;
    public int MaxMana;
    public int Level;
    public int MaxLevel;
    public int Experience;
    public int AttackDamage;
    public int AttackReach;
    public int SpecialAttackReach;
    public int ArmorLevel;
    public int WalkSpeed;
    public int RunSpeed;
    public int TurnSpeed;
    public int AttackDelay;
}

public class CharacterScript : MonoBehaviour {
    protected Rigidbody myBody;
    protected Animator myAnimator;
    protected bool isAttacking = false;
    public CharacterStats myStats = new CharacterStats();
    protected RaycastHit hit;
    protected GameObject hitenemy;

    // Use this for initialization
    virtual public void Start () {
        myBody = gameObject.GetComponentInChildren<Rigidbody>();
        myAnimator = gameObject.GetComponentInChildren<Animator>();
        myStats.isDead = false;
    }
	
	// Update is called once per frame
	virtual protected void Update () {
        statCheck();
	}

    private void statCheck()
    {

        if (myStats.Experience > (myStats.Level * 100) && myStats.Level < myStats.MaxLevel)
        {
            //Levelup();
        }

        if (myStats.Mana > myStats.MaxMana)
            myStats.Mana = myStats.MaxMana;
        if (myStats.Health > myStats.MaxHealth)
            myStats.Health = myStats.MaxHealth;

        if (myStats.Health <= 0)
        {
            myAnimator.SetBool("isDead", true);
            Invoke("Dead", 5);
        }
    }

    virtual protected void Move() { }

    virtual protected void Idle() { }

    virtual protected void Turn(){ }

    private void Jump()
    {
        //boing boing m'f'cker
    }

    protected void Attack()
    {
        isAttacking = true;
        if(myAnimator != null)
        myAnimator.SetBool("bIsAttacking", true);
        Invoke("DoDamage", .50f);
        Invoke("FinishAttack", .80f);
    }

    private void SpecialAttack()
    {
        isAttacking = true;
        if (myAnimator != null)
            myAnimator.SetBool("bIsAttacking", true);
        //currentWeapon.Invoke("Shoot", .50f);
        Invoke("FinishAttack", .80f);
    }

    private void DoDamage()
    {
        string Target;
        if(myStats.isPlayer == true)
        {
            Target = "Enemy";
        } else
        {
            Target = "Player";
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myStats.AttackReach))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit");
            if (hit.transform.gameObject.tag == Target)
            {
                hitenemy = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<CharacterScript>();
                hitenemy.GetComponent<CharacterScript>().myStats.Health -= myStats.AttackDamage;

                Debug.Log("Hit Target");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }
    
    private void FinishAttack()
    {
        if (myAnimator != null)
            myAnimator.SetBool("bIsAttacking", false);
        isAttacking = false;
    }

    virtual public void Dead()
    {
        if(myStats.isPlayer == false)
        gameObject.SetActive(false);
        //else set gamestate to dead.
    } 
}

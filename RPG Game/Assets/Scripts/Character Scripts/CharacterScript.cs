using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//lets you edit in unity
[System.Serializable]
public class CharacterStats
{
    public bool isPlayer;
    public bool isDead = false;

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
    public int inventorySize = 1;
}

public class CharacterScript : MonoBehaviour {
    protected Rigidbody myBody;
    protected Animator myAnimator;
    protected bool isAttacking = false;
    public CharacterStats myStats = new CharacterStats();
    protected RaycastHit hit;
    protected GameObject hitenemy;
    public GameObject currentWeapon;
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

    protected void statCheck()
    {

        if (myStats.Experience > (myStats.Level * 100) && myStats.Level < myStats.MaxLevel)
        {
            Levelup();
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
        if (isAttacking == false)
        {
            isAttacking = true;
            if (myAnimator != null)
                myAnimator.SetBool("isAttacking", true);
            Invoke("DoDamage", .50f);
            Invoke("FinishAttack", .80f);
        }
    }

    private void SpecialAttack()
    {
        isAttacking = true;
        if (myAnimator != null)
            myAnimator.SetBool("isAttacking", true);
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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myStats.AttackReach/2))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Hit");
            if (hit.transform.gameObject.tag == Target)
            {
                hitenemy = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<CharacterScript>();
                if (currentWeapon != null)
                    hitenemy.GetComponent<CharacterScript>().myStats.Health -= myStats.AttackDamage + currentWeapon.GetComponent<Weapon>().myStats.AttackDamage;
                else
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
            myAnimator.SetBool("isAttacking", false);
        isAttacking = false;
    }

    virtual public void Dead()
    {
        if(myStats.isPlayer == false)
        gameObject.SetActive(false);
        GameManager.CurrentState = GameManager.GameState.GameOver;
        //else set gamestate to dead.
    }

    protected void Levelup()
    {
        myStats.MaxHealth += 10;
        myStats.MaxMana += 10;
        myStats.AttackDamage += 2;
        myStats.Experience = 0;
        myStats.Level++;
    }
}

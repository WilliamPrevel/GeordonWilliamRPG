using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechEnemyScript : RoamingEnemyScript{
    public GameObject newFire;
    enum AIstate {Strafing, Roaming, Fleeing, Charging, Firing, Dead};
    AIstate currentState;
    public int fleetimer = 100;
   public int timerReset = 100;
    public int attackTimer = 100;
    public int attackTimerReset = 100;
    public GameObject turret;
    private void OnEnable()
    {
         newFire.SetActive(false);
        //player = manman.thePlayer;
    }
   

    override protected void Update()
    {
        //set aistate 
        if (currentState != AIstate.Fleeing && currentState != AIstate.Dead) {
            if (Vector3.Distance(player.transform.position, this.transform.position) < sightDistance)
            {
                currentState = AIstate.Strafing;
            } else
            {
                currentState = AIstate.Roaming;
            }
            if (myStats.Health <= 0)
            {
                myAnimator.SetBool("isDead", true);
                currentState = AIstate.Dead;
                myStats.isDead = true;
                Invoke("Dead", 5);
            }
        }
        if (fleetimer <= 0)
        {
            fleetimer = timerReset;
            currentState = AIstate.Strafing;
        }
        //invoke behaviour
        if (currentState == AIstate.Roaming)
        {
            if (roamTime <= 0)
            {
                roamTime = roam;
                Roam();
            myAnimator.SetBool("isWalking", true);
            }
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
        if (currentState == AIstate.Strafing)
        {
            myAnimator.SetBool("isStrafing", true);
            Strafe();
            attackTimer--;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerReset;
                Shoot();
            }
        } else
        {
            myAnimator.SetBool("isStrafing", false);
        }
        if (currentState == AIstate.Fleeing)
        {
            myAnimator.SetBool("isWalking", true);
            fleetimer--;
           Retreat();
        }
    }

    override protected void Roam()
    {
       
        Vector2 getdestination = Random.insideUnitCircle * roamdistance;
        destination = new Vector3(getdestination.x, 0, getdestination.y);
        Quaternion restrictor = Quaternion.Euler(0, 1, 0);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination), myStats.TurnSpeed) * restrictor;
        destination = destination - (transform.position);
        myBody.velocity = gameObject.transform.forward * myStats.WalkSpeed;
    }

    private void Strafe()
    {
            Vector3 direction = player.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction) * restrictor, myStats.TurnSpeed);

            if (direction.magnitude > 5)
            {
            myAnimator.SetBool("isWalking", true);
            this.transform.Translate(0, 0, 0.1f);

            }
            
    }
    private void Retreat()
    {
        myBody.velocity = gameObject.transform.forward * -myStats.RunSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        currentState = AIstate.Fleeing;
    }
   protected void Shoot()
   {

        GameObject newnew = Instantiate(newFire, this.turret.gameObject.transform.position, this.gameObject.transform.rotation);
        newnew.transform.parent = transform;
        newnew.SetActive(true);
        newnew.transform.position += new Vector3(0, 2, 2);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, myStats.SpecialAttackReach))
        {
            SoundManager.instance.PlaySound("Fire");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.transform.gameObject.tag == "Player")
            {
                hitenemy = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<PlayerScript>();
                hitenemy.GetComponent<PlayerScript>().myStats.Health -= myStats.AttackDamage;
                Debug.Log("LASER HIT");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("LASER MISS");
        }
    }

}



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

    private void OnEnable()
    {
         newFire.SetActive(false);
        //player = manman.thePlayer;
    }
   

    void Update()
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
            if (HP <= 0)
            {
                currentState = AIstate.Dead;
                isDead = true;
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
            }
        }
        if (currentState == AIstate.Strafing)
        {
            Strafe();
            attackTimer--;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerReset;
                Shoot();
            }
        }
        if (currentState == AIstate.Fleeing)
        {
            fleetimer--;
           Retreat();
        }
    }

    override protected void Roam()
    {
       
        Vector2 getdestination = Random.insideUnitCircle * roamdistance;
        destination = new Vector3(getdestination.x, 0, getdestination.y);
        Quaternion restrictor = Quaternion.Euler(0, 1, 0);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination), turnSpeed) * restrictor;
        destination = destination - (transform.position);
        mybody.velocity = gameObject.transform.forward * speed;
    }

    private void Strafe()
    {
            Vector3 direction = player.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction) * restrictor, turnSpeed);

            if (direction.magnitude > 5)
            {

                this.transform.Translate(0, 0, 0.1f);

            }
            
    }
    private void Retreat()
    {
        mybody.velocity = gameObject.transform.forward * -speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        currentState = AIstate.Fleeing;
    }
   protected void Shoot()
   {
        GameObject newnew = Instantiate(newFire, this.gameObject.transform.position, this.gameObject.transform.rotation);// Quaternion.identity);
        newnew.transform.parent = transform;
    newnew.SetActive(true);
        newnew.transform.position += new Vector3(0, 2, 2);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponLength))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.transform.gameObject.tag == "Player")
            {
                hitplayer = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<playerscript>();
                hitplayer.GetComponent<playerscript>().HP -= attackDamage;
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



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyScript : Enemy {

    protected Vector3 destination = new Vector3(0, 0, 0);
    public int roamdistance = 30;
    public int roamTime = 10;
    protected int roam = 10;
    
    // Use this for initialization
    override public void Start () {
        base.Start();
        roam = roamTime;
        rotator = transform.rotation;
        myBody = GetComponentInChildren<Rigidbody>();
        //player = manman.thePlayer;
    }
	
	// Update is called once per frame
    private void FixedUpdate()
    {
        roamTime--;
        if (roamTime <= 0)
        {
            roamTime = roam;
            Roam();
        }
    }

    override protected void Roam()
    {
        Vector2 getdestination = Random.insideUnitCircle * roamdistance;
        destination = new Vector3(getdestination.x, 0, getdestination.y);
            if (EnemyType == "SpiderLady")
            {
            myAnimator.SetBool("isWalking", true);
            }
        Quaternion restrictor = Quaternion.Euler(0,1,0);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination), myStats.TurnSpeed) * restrictor;
        destination = destination - (transform.position);
        myBody.velocity = gameObject.transform.forward * myStats.WalkSpeed;
    }
}

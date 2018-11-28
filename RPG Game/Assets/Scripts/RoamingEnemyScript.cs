using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyScript : Enemy {

    private float random;
    protected Vector3 destination = new Vector3(0, 0, 0);
    public int roamdistance = 30;
    public int roamTime = 10;
    protected int roam = 10;
    
    // Use this for initialization
    void Start () {
        roam = roamTime;
        rotator = transform.rotation;
        mybody = GetComponentInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
    private void FixedUpdate()
    {
        random = Random.Range(-10f, 10.0f);
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
                anim.SetBool("isWalking", true);
            }
        Quaternion restrictor = Quaternion.Euler(0,1,0);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination), turnSpeed) * restrictor;
        destination = destination - (transform.position);
        mybody.velocity = gameObject.transform.forward * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemyScript : Enemy {

    private float random;
    Vector3 destination = new Vector3(0, 0, 0);
    public int roamdistance = 30;
    public int roamTime = 10;
    private int roam = 10;
    // Use this for initialization
    void Start () {
        roam = roamTime;
       // InvokeRepeating("Roam", 5f, 1000);
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

    private void Roam()
    {
        destination = Random.insideUnitCircle * roamdistance;
            if (EnemyType == "SpiderLady")
            {
                anim.SetBool("isWalking", true);
            }
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            
        Quaternion.LookRotation(destination), turnSpeed);
        destination = destination - transform.position;
        if (destination.magnitude > 5)
        {

            this.transform.Translate(0, 0, 0.05f);

        }
      mybody.velocity = gameObject.transform.forward * speed;
    }
}

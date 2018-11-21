using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingEnemy : Enemy {

    private float random = Random.Range(1.0f , 10.0f);

    // Use this for initialization
    void Start () {

        InvokeRepeating("Roam", 5f, 1000);

    }
	
	// Update is called once per frame
	void Update () {


    }

    private void Roam()
    {
        if (Vector3.Distance(player.position, this.transform.position) > sightDistance)
        {
            Vector3 direction = new Vector3(transform.position.x + random, transform.position.y, transform.position.z + random);
        }
    }
}

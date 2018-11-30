using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEnemyScript : Enemy {

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
    }

    // Update is called once per frame
    private void FixedUpdate() {
        roamTime--;
        if (roamTime <= 0)
        {
            roamTime = roam;
            Roam();
        }
        gameObject.transform.rotation *= Quaternion.Euler(10, 1, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour {
    public LineRenderer laser;
    GameObject hitplayer;
    RaycastHit hit;
    public int range;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hitplayer = hit.transform.gameObject;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.transform.gameObject.tag == "Player")
            {
              //hitplayer = hit.transform.gameObject;
                hit.transform.gameObject.GetComponent<PlayerScript>();
                hitplayer.GetComponent<PlayerScript>().myStats.Health -= 1;
                // Debug.Log("Hit Player");
            }
        }
        for (int i = 0; i < range; i++)
        {
            laser.SetPosition(i,hit.transform.position);
        }
    }
}

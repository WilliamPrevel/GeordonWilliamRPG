using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomscript : MonoBehaviour {
   public static int spawncap = 100;
    int randomnumber;
   public GameObject newRoom;
   public GameObject[] PotentialRooms;
    public GameObject room1;
    public bool ISfINE = true;
    // Use this for initialization
    void Start () {
       Collider[] colliders = Physics.OverlapSphere(gameObject.transform.GetChild(1).position , 5);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.tag == "Room")
            {
                ISfINE = false;
                Object.Destroy(gameObject);
            }
        }
        if (spawncap > 0 && ISfINE)
        {
            spawnrooms();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spawnrooms()
    {
        //get the spawnpoints in parent transform
        foreach (Transform t in transform)
        {
            if (t.name == "Point1")//norm
            {
                spawncap--;
                randomnumber = Random.Range(0, PotentialRooms.Length);
                //newRoom = Instantiate(room1, t.transform.position, t.transform.rotation);
                newRoom = Instantiate(PotentialRooms[randomnumber], t.transform.position, t.transform.rotation);
            }
            else if (t.name == "Point2")//90
            {
                spawncap--;
                newRoom = Instantiate(room1, t.transform.position, t.transform.rotation);
            }
            else if (t.name == "Point3")//180
            {
                spawncap--;
                newRoom = Instantiate(room1, t.transform.position, t.transform.rotation);
            }
            else if (t.name == "Point4")//270
            {
                spawncap--;
                newRoom = Instantiate(room1, t.transform.position, t.transform.rotation);
            }
        }
    }

    
}

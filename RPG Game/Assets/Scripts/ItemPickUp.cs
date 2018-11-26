using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {
    public GameObject player;
    public int expvalue = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            gotoPlayer();
            Invoke("Despawn", 3);
        }
    }

    private void gotoPlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        while (direction.x + direction.y + direction.z > 0.2)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 90);
            this.transform.Translate(0, 0, 0.2f);
        }
    }

    private void DeSpawn()
    {
        //return to object pool
        gameObject.SetActive(false);
        player.GetComponent<playerscript>().exp += expvalue;
    }
}

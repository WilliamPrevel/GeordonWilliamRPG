using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {
    public GameObject player;
    public int expvalue = 10;
    public int manavalue = 10;
    public int healthvalue = 10;
    private bool approachPlayer = false;
    public bool isEXP = true;
    public bool isHP = false;
    public bool isMana = false;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
 Vector3 direction = player.transform.position - this.transform.position;
        if (approachPlayer) { 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 90);
            this.transform.Translate(0, 0, 0.2f);
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            gotoPlayer();
            Invoke("DeSpawn", 0.2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            DeSpawn();
        }
    }
    private void gotoPlayer()
    {
        approachPlayer = true;
    }

    private void DeSpawn()
    {
        //return to object pool
        gameObject.SetActive(false);
        //giveboost
        if(isEXP)
            player.GetComponent<PlayerScript>().myStats.Experience += expvalue;
        if(isHP)
            player.GetComponent<PlayerScript>().myStats.Health += healthvalue;
        if (isMana)
              player.GetComponent<PlayerScript>().myStats.Mana += manavalue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public GameObject player;
    public int expvalue = 10;
    public int manavalue = 10;
    public int healthvalue = 10;
    public bool isHeld = false;
    public bool isGateKey = false;
    private bool approachPlayer = false;
    public enum ItemType { ExpBoost, HealthBoost, ManaBoost, SuperBoost, ZPM, Weapon, Armour }
    public ItemType myType = ItemType.ExpBoost;

    // Use this for initialization
    protected void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Vector3 direction = player.transform.position - this.transform.position;

        if (approachPlayer)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 90);
            this.transform.Translate(0, 0, 0.2f);
        }
    }

    protected void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" & !isHeld)
        {
            gotoPlayer();
            Invoke("DeSpawn", 0.2f);
        }
    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player" & !isHeld)
        {
            DeSpawn();
        }
    }
    protected void gotoPlayer()
    {
        approachPlayer = true;
    }

    protected void DeSpawn()
    {
        switch (myType)
        {
            case ItemType.ExpBoost:
                player.GetComponent<PlayerScript>().myStats.Experience += expvalue;
                break;
            case ItemType.HealthBoost:
                player.GetComponent<PlayerScript>().myStats.Health += healthvalue;
                break;
            case ItemType.ManaBoost:
                player.GetComponent<PlayerScript>().myStats.Mana += manavalue;
                break;
            case ItemType.SuperBoost:
                player.GetComponent<PlayerScript>().myStats.Experience += expvalue;
                player.GetComponent<PlayerScript>().myStats.Health += healthvalue;
                player.GetComponent<PlayerScript>().myStats.Mana += manavalue;
                break;
            case ItemType.ZPM:
                player.GetComponent<PlayerScript>().hasZPM = 1;
                break;
            case ItemType.Weapon:
                //add weapon to weapon array
                GameManager.Inventory.Add(GetComponent<Weapon>().myStats);
                player.GetComponent<PlayerScript>().currentWeapon = gameObject;
                GameManager.CurrentMessage = "You found a " + this.GetComponent<Weapon>().myStats.weaponName + "\n\n " + this.GetComponent<Weapon>().myStats.weaponDescription;
                GameManager.CurrentState = GameManager.GameState.Dialogue;
                break;
            case ItemType.Armour:
                //add weapon to weapon array
                GameManager.Inventory2.Add(GetComponent<Armour>().myStats);
                player.GetComponent<PlayerScript>().currentArmour = gameObject;
                GameManager.CurrentMessage = "You found a " + this.GetComponent<Armour>().myStats.armourName + "\n\n " + this.GetComponent<Armour>().myStats.armourDescription;
                GameManager.CurrentState = GameManager.GameState.Dialogue;
                break;
        }
        //return to object pool!! TODO
        gameObject.SetActive(false);
        //giveboost
    }
}

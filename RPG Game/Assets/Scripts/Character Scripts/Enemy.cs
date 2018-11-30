using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterScript
{
    public Transform exphats;
    public Transform hphats;
    public Transform mphats;
    public Transform superhats;
    public GameObject player;
    protected Quaternion rotator;
    protected Quaternion restrictor = Quaternion.Euler(0, 1, 0);
    public string EnemyType;
    public float sightDistance = 10;
    protected bool droppedloot = false;
    //protected GameObject hitplayer;

    override public void Start()
    {
        base.Start();
        //player = GameObject.FindWithTag("Player");
        rotator = transform.rotation;
        //myBody = GetComponentInChildren<Rigidbody>();
        player = GameObject.Find("Player");

    }

    override protected void Update()
    {

        if (Vector3.Distance(player.transform.position, this.transform.position) < sightDistance)

        {
            if (EnemyType == "SpiderLady")
            {
                myAnimator.SetBool("isAttacking", true);
            }
            Vector3 direction = player.transform.position - this.transform.position;
            //1 attack at a time
            if (isAttacking == false)
            {
                Attack();
                Debug.Log("Attack!");
            }

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,

            Quaternion.LookRotation(direction) * restrictor, myStats.TurnSpeed);

            if (direction.magnitude > 5)
            {

                this.transform.Translate(0, 0, 0.05f);

            }

        }
        else if (EnemyType == "SpiderLady")
        {
            myAnimator.SetBool("isAttacking", false);
        }
        if (myStats.Health <= 0)
        {
            myStats.isDead = true;
            if (EnemyType == "SpiderLady")
            {
                myAnimator.SetBool("isDead", true);
            }
            Invoke("Dead", 5);
        }

    }
    override public void Dead() {
        if (droppedloot == false)
        {
            DropLoot();
        }
        base.Dead();
    }

    private void DropLoot()
    {
        int expdrops = Random.Range(1, 10);
        int hpdrops = Random.Range(2, 3);
        int mpdrops = Random.Range(2, 3);
        int superdrops = Random.Range(0, 1);

        for (int i = 0; i < expdrops; i++)
        {
            Instantiate(exphats, this.gameObject.transform.position, Quaternion.identity);
            exphats.GetComponent<ItemPickUp>().player = player;
        }
        for (int i = 0; i < hpdrops; i++)
        {
            Instantiate(hphats, this.gameObject.transform.position, Quaternion.identity);
            hphats.GetComponent<ItemPickUp>().player = player;
        }
        for (int i = 0; i < mpdrops; i++)
        {
            Instantiate(mphats, this.gameObject.transform.position, Quaternion.identity);
            mphats.GetComponent<ItemPickUp>().player = player;
        }
        for (int i = 0; i < superdrops; i++)
        {
            Instantiate(superhats, this.gameObject.transform.position, Quaternion.identity);
            superhats.GetComponent<ItemPickUp>().player = player;
        }
        droppedloot = true;
}
  protected virtual void Roam()
    {

    }
}

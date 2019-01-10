﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterScript
{
    public bool bossmonster = false;
    public Transform exphats;
    public int exphatmax;
    public Transform hphats;
    public int hphatmax;
    public Transform mphats;
    public int mphatmax;
    public Transform superhats;
    public int superhatmax;
    public Transform vpm;
    public int vpmmax;
    public GameObject player;
    protected Quaternion rotator;
    protected Quaternion restrictor = Quaternion.Euler(0, 1, 0);
    public string EnemyType;
    public float sightDistance = 10;
    protected bool droppedloot = false;
    public bool isQuestEnemy = false;
    public int QuestKillAmmount;
    
    
    //protected GameObject hitplayer;

    override public void Start()
    {
        base.Start();
        rotator = transform.rotation;
        player = GameObject.Find("Player");
       // QuestKillAmmount = GetComponent<QuestManager>().CurrentAmmount;

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
        if (isQuestEnemy == true)
        {
            QuestKillAmmount++;
        }
        base.Dead();
    }

    protected void DropLoot()
    {
        int expdrops = Random.Range(1, 10);
        int hpdrops = Random.Range(2, 3);
        int mpdrops = Random.Range(2, 3);
        int superdrops = Random.Range(0, 1);
        int VPM = Random.Range(1, 1);
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
        for (int i = 0; i < VPM; i++)
        {
            if (vpm != null && bossmonster == true)
            {
                Instantiate(vpm, this.gameObject.transform.position, Quaternion.identity);
                vpm.GetComponent<ItemPickUp>().player = player;
            }
        }
        droppedloot = true;
}
  protected virtual void Roam()
    {

    }
}

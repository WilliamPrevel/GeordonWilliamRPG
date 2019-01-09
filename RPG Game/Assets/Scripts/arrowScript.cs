using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    private SoundManager soundManager;
    public float movespeed = 0.2f;
    public float killtime = 100;
    public int power = 10;
    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlaySound("Magic");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * movespeed);
        killtime--;
        if (killtime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        movespeed = 0;
        //if (collision.gameObject.tag == "Enemy")
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().myStats.Health -= power;
        }
    }
}

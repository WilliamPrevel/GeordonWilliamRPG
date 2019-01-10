using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject Player;
    public int childnum = 1;
    public GameObject targetTele;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        foreach (Transform t in transform)
        {
            if (t.name == "Spot1" && collision == t)//norm
            {
                childnum = 2;
            }
            if (t.name == "Spot2" && collision == t)//norm
            {
                childnum = 3;
            }
            if (t.name == "Spot3" && collision == t)//norm
            {
                childnum = 4;
            }
            if (t.name == "Spot4" && collision == t)//norm
            {
                childnum = 1;
            }
        }
        Invoke("TeleportPlayer", 1);
    }
    void TeleportPlayer()
    {
        Player.transform.position = gameObject.GetComponentInParent<Transform>().GetChild(childnum).transform.position;
    }
}

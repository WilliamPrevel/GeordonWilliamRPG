using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gatescript : MonoBehaviour
{
    public string sceneto = "sample scene";
    public int playerLevelRequired;
    private int LV;
    private GameObject player;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        LV = player.GetComponentInParent<playerscript>().PlayerStatInfo.LV;
        if (LV >= playerLevelRequired)
        {

            if (other.gameObject.tag == "Player")
            {
                GameManager.instance.getPlayerStats();
                SceneManager.LoadScene(sceneto, LoadSceneMode.Single);

            }
        }
    }
}

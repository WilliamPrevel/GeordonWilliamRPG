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
        Debug.Log("STARGATE WTF YO");
        LV = player.GetComponentInParent<playerscript>().LV;
        if (LV >= playerLevelRequired)
        {
            Debug.Log("STARGATE WTF YO");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("STARGATE WTF YO");
                SceneManager.LoadScene(sceneto, LoadSceneMode.Single);

            }
        }
    }
}

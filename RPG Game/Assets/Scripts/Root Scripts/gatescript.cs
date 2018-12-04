using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gatescript : MonoBehaviour
{
    public string sceneto = "sample scene";
    public int VPM = 1;
    private int LV;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.GetComponentInParent<PlayerScript>().hasZPM >= VPM)
        {
                GameManager.instance.getPlayerStats();
                SceneManager.LoadScene(sceneto, LoadSceneMode.Single);
        }
    }
}

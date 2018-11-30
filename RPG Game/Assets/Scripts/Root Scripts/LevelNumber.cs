using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour {

    private int level;
    Text LevelText;
    public GameObject Player;
    
    

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        LevelText = gameObject.GetComponent<Text>();
        level = Player.GetComponentInParent<PlayerScript>().myStats.Level;
        LevelText.text = "" + level;

    }
	
	// Update is called once per frame
	void Update () {
        
        LevelText.text = "" + level;
        
	}
}

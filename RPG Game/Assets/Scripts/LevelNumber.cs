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
        LevelText = gameObject.GetComponent<Text>();
        level = Player.GetComponentInParent<playerscript>().LV;
        LevelText.text = "" + level;

    }
	
	// Update is called once per frame
	void Update () {
        
        LevelText.text = "" + level;
        
	}
}

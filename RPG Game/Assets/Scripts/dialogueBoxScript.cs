using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueBoxScript : MonoBehaviour {
    public GameObject dialoguer;
    public Text dialogueText;
    // Use this for initialization
    void Start () {
        //dialoguer = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.CurrentState == GameManager.GameState.Dialogue)
        {
            dialoguer.SetActive(true);
        } else
        {
            dialoguer.SetActive(false);
        }
        //this._alpha = 100;
        //remove from update later, for now lets get it working.
        dialogueText.text = GameManager.CurrentMessage;
	}
    
}

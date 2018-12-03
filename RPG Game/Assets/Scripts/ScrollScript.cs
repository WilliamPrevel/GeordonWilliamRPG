using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {
    public string myMessage = "I am Error";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Player")
        {
            GameManager.CurrentMessage = myMessage;
            GameManager.CurrentState = GameManager.GameState.Dialogue;
            Debug.Log("SAYSTUFF");

        }
    }
}

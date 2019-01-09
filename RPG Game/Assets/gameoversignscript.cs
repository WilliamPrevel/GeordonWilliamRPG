using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoversignscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.CurrentState == GameManager.GameState.GameOver)
        {
            transform.localScale = new Vector3 (100, 100, 100);
        } else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
	}
}

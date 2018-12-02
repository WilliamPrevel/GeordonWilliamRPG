using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribbonscript : MonoBehaviour {
    public int turnrate = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation *= Quaternion.Euler(1, turnrate * Time.deltaTime, 1);
	}
}


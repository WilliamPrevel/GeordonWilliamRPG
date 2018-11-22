using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribbonscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation *= Quaternion.Euler(10, 1, 1);
	}
}

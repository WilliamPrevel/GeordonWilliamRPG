using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraspinscript : MonoBehaviour {
    public float turnrate = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, 0,turnrate * Time.deltaTime);
    }
}

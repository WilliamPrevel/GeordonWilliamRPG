﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPurposePool : MonoBehaviour {

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public static MultiPurposePool SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        
    }
    //return to pool
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] && !pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}

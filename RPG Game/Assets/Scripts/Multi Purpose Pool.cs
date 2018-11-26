using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPurposePool : MonoBehaviour {

    public List<GameObject> pooledObjects;
    public GameObject objectToPoolA;
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
            pooledObjects.Add(setGameObj(objectToPoolA));
        }

    }

    GameObject setGameObj(GameObject objToPool)
    {
        GameObject obj = (GameObject)Instantiate(objToPool);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] && !pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        GameObject blah = null;
        if (tag == objectToPoolA.tag)
        {
            blah = objectToPoolA;
        }
        
        

        GameObject obj = (GameObject)Instantiate(blah);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject gameManager;

    private void Start()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        else
            GameManager.instance.StartUpManager();
    }

    // Use this for initialization
    void Awake ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

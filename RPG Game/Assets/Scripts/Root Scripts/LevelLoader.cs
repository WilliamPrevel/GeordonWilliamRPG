using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject gameManager;
    //public GameObject eventManager;

    private void Start()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        else
            GameManager.instance.StartUpManager();

        //if (InputManager.instance == null)
        //    Instantiate(eventManager);

    }

    // Use this for initialization
    void Awake ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

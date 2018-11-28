using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerStats
{

}

public class GameManager : MonoBehaviour {

    public List <MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public int gameEventID = 0;
    public int Testor = 0;
    private static GameManager instanciate;


    public static GameManager instance = null;
    public playerscript player;
    public GameObject thePlayer;
    //make private
    public int HP = 100;
    public int MP = 100;
    public int EXP = 0;


    //    public static GameManager Instanciate
    //    {
    //        get
    //        {
    //            if(instanciate == null)
    //            {
    //                instanciate = FindObjectOfType<GameManager>();
    //#if UNITY_EDITOR
    //                if (FindObjectsOfType<GameManager>().Length > 1)
    //                {
    //                    Debug.LogError("There is more than 1 game manager in the scene");
    //                }
    //#endif
    //            }
    //            return instanciate;
    //        }
    //    }
    private void Start()
    {

        thePlayer = GameObject.FindWithTag("Player");
        StartUpManager();
    }

    void Awake ()
    {
    }

    public void StartUpManager()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerscript>();

        InitGame();
    }

    void InitGame()
    {
        if (player)
        {

            player.SetupPlayer(HP);
            player.SetupPlayer(MP);
            player.SetupPlayer(EXP);
        }
    }

    public void subscribeToGameEventUpdate(MonoBehaviour pScript)
    {
        eventSubscribedScripts.Add(pScript);
    }
    public void deSubscribeToGameEventUpdate(MonoBehaviour pScript)
    {
        while (eventSubscribedScripts.Contains(pScript))
        {
            eventSubscribedScripts.Remove(pScript);
        }
    }

    public void playerPassedEvent()
    {
        gameEventID++;
        foreach(MonoBehaviour _script in eventSubscribedScripts)
        {
            _script.Invoke("gameEventUpdated",0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

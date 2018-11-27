using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List <MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public int gameEventID = 0;
    private static GameManager instanciate;

    public static GameManager Instanciate
    {
        get
        {
            if(instanciate == null)
            {
                instanciate = FindObjectOfType<GameManager>();
#if UNITY_EDITOR
                if (FindObjectsOfType<GameManager>().Length > 1)
                {
                    Debug.LogError("There is more than 1 game manager in the scene");
                }
#endif
            }
            return instanciate;
        }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        Invoke("playerPassedEvent", 2f);
        Invoke("playerPassedEvent", 4f);

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

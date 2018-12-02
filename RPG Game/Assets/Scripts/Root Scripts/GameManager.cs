using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedStats
{
    public int Health;
    public int MaxHealth;
    public int Mana;
    public int MaxMana;
    public int Level;
    public int MaxLevel;
    public int Experience;
    public int AttackDamage;
    public int ArmorLevel;
}

public class GameManager : MonoBehaviour {

    private static GameManager instanciate;
    public static GameManager instance = null;
    public enum GameState { MainMenu, Playing, Pause, Dialogue, CutScene, Inventory, TBD};
    public static GameState CurrentState;
    public GameObject thePlayer;
    public SavedStats PlayerCurrentInfo = new SavedStats();
    public static string CurrentMessage;
    private void Start()
    {

        thePlayer = GameObject.FindWithTag("Player");
        StartUpManager();

    }

    public void StartUpManager()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    public void getPlayerStats()
    {
        PlayerCurrentInfo.Health = thePlayer.GetComponent<PlayerScript>().myStats.Health;
        PlayerCurrentInfo.Mana = thePlayer.GetComponent<PlayerScript>().myStats.Mana;
        PlayerCurrentInfo.Experience = thePlayer.GetComponent<PlayerScript>().myStats.Experience;
        PlayerCurrentInfo.Level = thePlayer.GetComponent<PlayerScript>().myStats.Level;
        PlayerCurrentInfo.MaxHealth = thePlayer.GetComponent<PlayerScript>().myStats.MaxHealth;
        PlayerCurrentInfo.MaxMana = thePlayer.GetComponent<PlayerScript>().myStats.MaxMana;
    }

    void InitGame()
    {
        if (thePlayer != null)
        {

            thePlayer.GetComponent<PlayerScript>().SetupPlayer(PlayerCurrentInfo);

        }
    }

    //public void subscribeToGameEventUpdate(MonoBehaviour pScript)
    //{
    //    eventSubscribedScripts.Add(pScript);
    //}
    //public void deSubscribeToGameEventUpdate(MonoBehaviour pScript)
    //{
    //    while (eventSubscribedScripts.Contains(pScript))
    //    {
    //        eventSubscribedScripts.Remove(pScript);
    //    }
    //}

 //   public void playerPassedEvent()
 //   {
 //       gameEventID++;
 //       foreach(MonoBehaviour _script in eventSubscribedScripts)
 //       {
 //           _script.Invoke("gameEventUpdated",0);
 //       }
 //   }

 //   // Update is called once per frame
       void Update () {
		
	    }
}

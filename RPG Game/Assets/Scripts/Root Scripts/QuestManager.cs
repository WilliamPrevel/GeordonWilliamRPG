using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public ScrollScript QuestInfo;
    public int QuestKillAmmount;
    public int CurrentAmmount;
	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
       if(GameManager.currentQuest != GameManager.QuestType.None)
        {
            GameManager.CurrentState = GameManager.GameState.Playing;
        }
        else
        {
           if(CurrentAmmount >= QuestKillAmmount)
            {
                GameManager.currentQuest = GameManager.QuestType.None;
            }
        }
       
    }
}

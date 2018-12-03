using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public int QuestAmmount;
    private int CurrentAmmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if(GameManager.currentQuest != GameManager.QuestType.None)
        {
            
        }
        else
        {

        }
       
    }
}

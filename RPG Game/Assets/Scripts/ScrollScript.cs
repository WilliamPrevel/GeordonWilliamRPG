using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public string myMessage = "I am Error";
    public bool HasQuest = false;
    public bool IsQuestKill = false;
    public bool IsQuestFind = false;
    public bool IsQuestAvoid = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.CurrentMessage = myMessage;
            GameManager.CurrentState = GameManager.GameState.Dialogue;
            Debug.Log("SAYSTUFF");

            if (HasQuest == true)
            {
                if (IsQuestKill == true)
                {
                    GameManager.currentQuest = GameManager.QuestType.Kill;
                }
                if (IsQuestFind == true)
                {
                    GameManager.currentQuest = GameManager.QuestType.Find;
                }
                if (IsQuestAvoid == true)
                {
                    GameManager.currentQuest = GameManager.QuestType.Avoid;
                }
            }

        }
    }
}

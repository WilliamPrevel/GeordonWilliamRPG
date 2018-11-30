using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QuestSystem
{
    public class KillObjective : IQuestObj
    {

        private string title;
        private string description;
        private bool isComplete;
        private string verb;
        private int ammountKillNeeded;
        private int currentKilled;
        private GameObject enemyToKill;

        public KillObjective(string titleVerb, int totalAmmount, GameObject enemy, string descrip)
        {
            title = titleVerb + " " + totalAmmount + " " + enemy.name;
            verb = titleVerb;
            description = descrip;
            ammountKillNeeded = totalAmmount;
            currentKilled = 0;
            CheckProgress(); 
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public int AmmountKillNeeded
        {
            get
            {
                return ammountKillNeeded;
            }
        }

        public int CurrentKilled
        {
            get
            {
                return currentKilled;
            }
        }

        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
        }

        public GameObject EnemyToKill
        {
            get
            {
                return enemyToKill;
            }
        }

        public void CheckProgress()
        {
            if (currentKilled >= ammountKillNeeded)
                isComplete = true;
            else
                isComplete = false;
        }

        public void UpdateProgress()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return currentKilled + "/" + ammountKillNeeded + " " + enemyToKill.name + " " + verb + "ed.";
        }
    }
}
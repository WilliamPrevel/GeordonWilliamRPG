using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QuestSystem
{
    public class QuestIdentifier : IQuestIdentifiers
    {
        private int id;
        private int sourceID;

        public int ID
        {
            get
            {
                return id;
            }
        }

        public int SourceID
        {
            get
            {
                return sourceID;
            }
        }

    }
}

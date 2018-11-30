using System.Collections.Generic;

namespace QuestSystem
{
    
    public class Quest
    {
        public Quest()
        {

        }
        private List<IQuestObj> objectives;


        private bool IsComplete()
        {
            for (int i = 0; i < objectives.Count; i++)
            {
                if (objectives[i].IsComplete != false)
                {
                    return false;
                }
            }

            return true;
        }
    }
    
}


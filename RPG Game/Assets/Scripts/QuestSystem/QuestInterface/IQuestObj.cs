using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {

	public interface IQuestObj
    {
        string Title { get; }
        string Description { get; }

        bool IsComplete { get; }

        void UpdateProgress();
        void CheckProgress() ;

    }
}

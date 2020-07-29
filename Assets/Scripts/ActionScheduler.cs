using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{

    public class ActionScheduler : MonoBehaviour
    {

        MonoBehaviour currentAction;
        public void StartAction(MonoBehaviour action)
        {
            if (currentAction != null) return;
            {
                print("Cancelling action" + currentAction);
            }

            currentAction = action;
            
        }
    }
}

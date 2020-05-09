using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Resets the FungusPriority count to zero. Useful if you are among logic that is hard to have matching increase and decreases.
    /// </summary>
<<<<<<< HEAD
    [CommandInfo("PrioritySignals",
=======
    [CommandInfo("Priority Signals",
>>>>>>> c16a4ba44c6bdef2175a38af61ead757c30ca5dc
                 "Priority Reset",
                 "Resets the FungusPriority count to zero. Useful if you are among logic that is hard to have matching increase and decreases.")]
    public class FungusPriorityReset : Command
    {
        public override void OnEnter()
        {
            FungusPrioritySignals.DoResetPriority();

            Continue();
        }
    }
}
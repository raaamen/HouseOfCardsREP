using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Decrease the FungusPriority count, causing the related FungusPrioritySignals to fire.
    /// Intended to be used to notify external systems that fungus is doing something important and they should perhaps resume.
    /// </summary>
<<<<<<< HEAD
    [CommandInfo("PrioritySignals",
=======
    [CommandInfo("Priority Signals",
>>>>>>> c16a4ba44c6bdef2175a38af61ead757c30ca5dc
                 "Priority Down",
                 "Decrease the FungusPriority count, causing the related FungusPrioritySignals to fire. " +
                "Intended to be used to notify external systems that fungus is doing something important and they should perhaps resume.")]
    public class FungusPriorityDecrease : Command
    {
        public override void OnEnter()
        {
            FungusPrioritySignals.DoDecreasePriorityDepth();

            Continue();
        }
    }
}
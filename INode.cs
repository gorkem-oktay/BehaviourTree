using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class INode
    {
        protected const bool debug = false;
        protected int ticks;

        protected bool starting = true;

        private static readonly List<string> debugTypeBlacklist = new List<string>
        {
            "Selector",
            "Sequence",
            "Repeater",
            "Inverter",
            "Succeeder"
        };

        public virtual Status Behave(IContext context)
        {
            var result = OnBehave(context);

            if (debug && !debugTypeBlacklist.Contains(GetType().Name))
            {
                Debug.Log("Behaving: " + GetType().Name + " - " + result);
            }

            ticks++;
            starting = false;

            if (result != Status.RUNNING)
            {
                Reset();
            }

            return result;
        }

        public abstract Status OnBehave(IContext context);
        protected virtual void OnReset(){}

        public void Reset()
        {
            starting = true;
            ticks = 0;
            OnReset();
        }
    }
}
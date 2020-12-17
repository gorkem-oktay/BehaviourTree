using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree.Composite
{
    public abstract class IComposite : INode
    {
        protected readonly List<INode> children = new List<INode>();
        private readonly string compositeName;

        protected IComposite(string name, params INode[] nodes)
        {
            compositeName = name;
            children.AddRange(nodes);
        }

        public override Status Behave(IContext context)
        {
            var shouldLog = debug && ticks == 0;
            if (shouldLog)
            {
                Debug.Log("Running behaviour list: " + compositeName);
            }
            
            var result = base.Behave(context);

            if (debug && result != Status.RUNNING)
            {
                Debug.Log("Behaviour list " + compositeName + " returned: " + result);
            }

            return result;
        }
    }
}
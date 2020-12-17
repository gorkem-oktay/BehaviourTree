using System;

namespace BehaviourTree
{
    public class ActionNode : INode
    {
        private Action _action;

        public ActionNode(Action action)
        {
            _action = action;
        }
        
        public override Status OnBehave(IContext context)
        {
            _action?.Invoke();

            return Status.SUCCESS;
        }
    }
}
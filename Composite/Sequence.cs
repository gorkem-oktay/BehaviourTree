namespace BehaviourTree.Composite
{
    public class Sequence : IComposite
    {
        public Sequence(string compositeName, params INode[] nodes) : base(compositeName, nodes)
        {
        }

        public override Status OnBehave(IContext context)
        {
            var anyChildRunning = false; 
         
            foreach(var child in children) { 
                switch (child.Behave(context)) { 
                    case Status.FAILURE:
                        return Status.FAILURE;                     
                    case Status.SUCCESS: 
                        continue; 
                    case Status.RUNNING: 
                        anyChildRunning = true; 
                        continue; 
                    default:
                        return Status.RUNNING; 
                } 
            }
            return anyChildRunning ? Status.RUNNING : Status.SUCCESS;
        }

        protected override void OnReset()
        {
            foreach(var child in children)
            {
                child.Reset();
            }
        }
    }
}
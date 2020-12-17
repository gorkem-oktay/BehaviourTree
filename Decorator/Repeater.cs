namespace BehaviourTree.Decorator
{
    public class Repeater : IDecorator
    {
        public Repeater(INode child) : base(child)
        {

        }
        public override Status OnBehave(IContext context)
        {
            var ret = child.Behave(context);
            
            if (ret != Status.RUNNING)
            {
                Reset();
                child.Reset();
            }
            
            return Status.SUCCESS;
        }
    }
}
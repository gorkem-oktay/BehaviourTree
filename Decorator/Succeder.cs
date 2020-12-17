namespace BehaviourTree.Decorator
{
    public class Succeeder : IDecorator
    {
        public Succeeder(INode child) : base(child)
        {

        }
        public override Status OnBehave(IContext context)
        {
            var ret = child.Behave(context);
            
            return ret == Status.RUNNING ? Status.RUNNING : Status.SUCCESS;
        }
    }
}
namespace BehaviourTree.Decorator
{
    public class Failer : IDecorator
    {
        public Failer(INode child) : base(child)
        {

        }
        public override Status OnBehave(IContext context)
        {
            child.Behave(context);
            return Status.FAILURE;
        }
    }
}
namespace BehaviourTree.Decorator
{
    public class Inverter : IDecorator
    {
        public Inverter(INode child) : base(child)
        {

        }
        public override Status OnBehave(IContext context)
        {
            switch(child.Behave(context))
            {
                case Status.SUCCESS:
                    return Status.FAILURE;
                case Status.FAILURE:
                    return Status.SUCCESS;
                case Status.RUNNING:
                default:
                    return Status.RUNNING;
            }
        }
    }
}
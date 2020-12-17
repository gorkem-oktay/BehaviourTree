namespace BehaviourTree.Composite
{
    public class Selector : IComposite
    {
        public Selector(string compositeName, params INode[] nodes) : base(compositeName, nodes)
        {
        }

        public override Status OnBehave(IContext context)
        {
            foreach (var child in children)
            {
                switch (child.Behave(context))
                {
                    case Status.FAILURE:
                        continue;
                    case Status.SUCCESS:
                        return Status.SUCCESS;
                    case Status.RUNNING:
                        return Status.RUNNING;
                    default:
                        continue;
                }
            }

            return Status.FAILURE;
        }

        protected override void OnReset()
        {
            foreach (var child in children)
            {
                child.Reset();
            }
        }
    }
}
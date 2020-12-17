namespace BehaviourTree.Decorator
{
    public abstract class IDecorator : INode
    {
        protected INode child;

        public IDecorator(INode node) {
            child = node;
        }
    }
}
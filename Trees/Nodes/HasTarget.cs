
namespace BehaviourTree
{
    public class HasTarget : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            return context.hasTarget ? Status.SUCCESS : Status.FAILURE;
        }
    }
}
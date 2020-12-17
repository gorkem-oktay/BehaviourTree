
namespace BehaviourTree
{
    public class WalkNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;
            
            //context.Self.GetMovement().Walk(context.Self.GetMovement().Destination);

            return Status.SUCCESS;
        }
    }
}
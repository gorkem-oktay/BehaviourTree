
namespace BehaviourTree
{
    public class RunNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;
            
            //context.Self.GetMovement().Run(context.Self.GetMovement().Destination);

            return Status.SUCCESS;
        }
    }
}
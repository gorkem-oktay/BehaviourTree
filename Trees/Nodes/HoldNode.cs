
namespace BehaviourTree
{
    public class HoldNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;
            
            //context.Self.GetMovement().Hold();
            
            return Status.SUCCESS;
        }
    }
}
using StatusSystem;

namespace BehaviourTree
{
    public class DoNothingNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.Self.GetStatusManager().HasStatus(StatusType.STUN))
            {
                return Status.FAILURE;
            }
            
            //context.Self.GetMovement().Hold();
            //context.Self.GetMovement().GetAnimator().SetBool("IsTerrified", false);
            return Status.SUCCESS;
        }
    }
}
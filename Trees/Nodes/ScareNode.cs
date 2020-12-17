
namespace BehaviourTree
{
    public class ScareNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            //context.Self.GetMovement().Hold();
            //context.Self.GetMovement().GetAnimator().SetBool("IsTerrified", true);
            context.Self.GetMovement().Look(context.Player.transform);

            return Status.SUCCESS;
        }
    }
}
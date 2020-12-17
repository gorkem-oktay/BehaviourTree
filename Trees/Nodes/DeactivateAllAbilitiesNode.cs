
namespace BehaviourTree
{
    public class DeactivateAllAbilitiesNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;
            
            context.Self.GetAbilityManager().DeactivaAll();

            return Status.SUCCESS;
        }
    }
}
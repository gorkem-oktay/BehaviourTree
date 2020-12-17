
namespace BehaviourTree
{
    public class ThrowNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.Self.GetAbilityManager().HasAbility(AbilityType.THROW))
            {
                return Status.FAILURE;
            }

            if (context.Self.GetAbilityManager().IsActive(AbilityType.THROW))
            {
                return Status.RUNNING;
            }

            context.Self.GetAbilityManager().Activate(AbilityType.THROW, context.Player.gameObject);
            return Status.SUCCESS;
        }
    }
}
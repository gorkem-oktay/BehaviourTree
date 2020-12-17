
namespace BehaviourTree
{
    public class DeactivateAbilityNode : INode
    {
        private readonly AbilityType _type;

        public DeactivateAbilityNode(AbilityType type)
        {
            _type = type;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.Self.GetAbilityManager().HasAbility(_type))
            {
                return Status.FAILURE;
            }

            if (context.Self.GetAbilityManager().IsActive(_type))
            {
                context.Self.GetAbilityManager().Deactivate(_type);                
            }

            return Status.SUCCESS;
        }
    }
}
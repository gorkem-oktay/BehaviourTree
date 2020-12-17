
namespace BehaviourTree
{
    public class IsAbilityOnCooldownNode : INode
    {
        private readonly AbilityType _type;

        public IsAbilityOnCooldownNode(AbilityType type)
        {
            _type = type;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            var abilityManager = context.Self.GetAbilityManager();

            if (!abilityManager)
            {
                return Status.FAILURE;
            }
            
            if (!abilityManager.HasAbility(_type))
            {
                return Status.FAILURE;
            }

            return abilityManager.IsOnCooldown(_type) ? Status.SUCCESS : Status.FAILURE;
        }
    }
}
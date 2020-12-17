
namespace BehaviourTree
{
    public class ActivateAbilityNode : INode
    {
        private readonly AbilityType _type;

        public ActivateAbilityNode(AbilityType type)
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

            if (abilityManager.IsActive(_type))
            {
                return Status.RUNNING;
            }
            
            if (abilityManager.IsOnCooldown(_type))
            {
                return Status.FAILURE;
            }

            abilityManager.Activate(_type, context.Target);
            
            return Status.SUCCESS;
        }
    }
}
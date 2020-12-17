
namespace BehaviourTree
{
    public class IsAbilityActiveNode : INode
    {
        private readonly AbilityType _type;

        public IsAbilityActiveNode(AbilityType type)
        {
            _type = type;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            return context.Self.GetAbilityManager().IsActive(_type) ? Status.SUCCESS : Status.FAILURE;
        }
    }
}
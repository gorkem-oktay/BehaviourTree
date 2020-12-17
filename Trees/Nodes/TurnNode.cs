
namespace BehaviourTree
{
    public class TurnNode : INode
    {
        private float _speed = 0f;
        
        public TurnNode(float speed)
        {
            _speed = speed;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.Target)
            {
                return Status.FAILURE;
            }
            
            context.Self.GetMovement().TurnTowards(context.Target.transform, _speed);

            return Status.SUCCESS;
        }
    }
}
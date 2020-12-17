
namespace BehaviourTree
{
    public class LockOnTargetNode : INode
    {
        private bool _changeDestination;
        
        public LockOnTargetNode(bool changeDestination = true)
        {
            _changeDestination = changeDestination;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.hasTarget)
            {
                return Status.FAILURE;
            }
            
            context.Self.GetMovement().Look(context.Target.transform);
            
            if (_changeDestination)
            {
                //context.Self.GetMovement().Destination = context.Target.transform.position;                
            }

            return Status.SUCCESS;
        }
    }    
}
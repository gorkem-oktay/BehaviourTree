using UnityEngine;

namespace BehaviourTree
{
    public class FleeNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (context.FleeDirection == Vector3.zero)
            {
                context.FleeDirection = (context.Self.GetMovement().transform.position - context.Player.transform.position).normalized;                
            }

            var newPosition = context.Self.GetMovement().transform.position + 2 * context.FleeDirection;
            
            //context.Self.GetMovement().Run(newPosition);
            return Status.SUCCESS;
        }
    }
}
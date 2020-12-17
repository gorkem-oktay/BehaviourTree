using EntityAttributes;
using UnityEngine;

namespace BehaviourTree
{
    public class IsPlayerCloseNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.hasPlayer)
            {
                //context.Self.GetMovement().GetAnimator().SetBool("IsTerrified", false);
                context.FleeDirection = Vector3.zero;
                return Status.FAILURE;
            }

            var currentDistance = (context.Self.GetMovement().transform.position - context.Player.transform.position).magnitude;
            
            if (currentDistance < context.Self.GetAttributeManager().ValueOf(AttributeType.Vision))
            {
                return Status.SUCCESS;
            }
            
            //context.Self.GetMovement().GetAnimator().SetBool("IsTerrified", false);
            context.FleeDirection = Vector3.zero;
            return Status.FAILURE;
        }
    }
}
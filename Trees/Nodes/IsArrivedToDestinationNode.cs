using UnityEngine;

namespace BehaviourTree
{
    public class IsArrivedToDestinationNode : INode
    {
        private readonly float _distanceToCheck;

        public IsArrivedToDestinationNode(float distanceToCheck = 0.5f)
        {
            _distanceToCheck = distanceToCheck;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            /*
            if (Vector3.Distance(context.Self.GetMovement().transform.position, context.Self.GetMovement().Destination) > _distanceToCheck)
            {
                return Status.FAILURE;
            }
            */

            return Status.SUCCESS;
        }
    }
}
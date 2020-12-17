using UnityEngine;

namespace BehaviourTree
{
    public class IsTargetInRangeNode : INode
    {
        private readonly float _range;

        public IsTargetInRangeNode(float range = 1f)
        {
            _range = range;
        }
        
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            if (!context.hasTarget)
            {
                return Status.FAILURE;
            }

            if (Vector3.Distance(context.Self.GetMovement().transform.position, context.Target.transform.position) > _range)
            {
                return Status.FAILURE;
            }

            return Status.SUCCESS;
        }
    }
}
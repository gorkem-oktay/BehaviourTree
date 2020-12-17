
namespace BehaviourTree
{
    public class ChangeDestinationNode : INode
    {
        public override Status OnBehave(IContext iContext)
        {
            var context = (EnemyBehaviourTreeContext) iContext;

            var randomPoint = context.Boundary.GetRandomPoint();
            
            var destination = context.Self.GetMovement().transform.position;
            destination.x = randomPoint.x;
            destination.z = randomPoint.z;

            //context.Self.GetMovement().Destination = destination;

            return Status.SUCCESS;
        }
    }
}
using BehaviourTree.Composite;
using BehaviourTree.Decorator;

namespace BehaviourTree
{
    public class CowardTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();

            var changeDestination = new ChangeDestinationNode();
            
            var isPlayerClose = new IsPlayerCloseNode();
            var scare = new ScareNode();
            var seqScare = new Sequence("ScareSequence", isPlayerClose, scare, changeDestination);

            var checkArrived = new IsArrivedToDestinationNode();
            var seqChangeDestination = new Sequence("ChangeDestinationSequence", checkArrived, changeDestination);
            var move = new WalkNode();
            var seqMove = new Sequence("MoveSequence", new Succeeder(seqChangeDestination), move);

            var selector = new Selector("ScareMoveSelector", doNothing, seqScare, seqMove);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
using BehaviourTree.Composite;
using BehaviourTree.Decorator;

namespace BehaviourTree
{
    public class FleerTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();

            var changeDestination = new ChangeDestinationNode();
            
            var isPlayerClose = new IsPlayerCloseNode();
            var run = new FleeNode();
            var seqRun = new Sequence("RunSequence", isPlayerClose, run, changeDestination);

            var checkArrived = new IsArrivedToDestinationNode();
            var seqChangeDestination = new Sequence("ChangeDestinationSequence", checkArrived, changeDestination);
            var move = new WalkNode();
            var seqMove = new Sequence("MoveSequence", new Succeeder(seqChangeDestination), move);

            var selector = new Selector("RunMoveSelector", doNothing, seqRun, seqMove);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
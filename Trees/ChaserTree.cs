using BehaviourTree.Composite;
using BehaviourTree.Decorator;

namespace BehaviourTree
{
    public class ChaserTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();
            
            var lockOn = new LockOnTargetNode();

            var checkDistanceForHold = new IsArrivedToDestinationNode(2f);
            var hold = new HoldNode();
            var seqCheckDistanceHold = new Sequence("MoveSequence", lockOn, checkDistanceForHold, hold);
            
            var move = new WalkNode();

            var selector = new Selector("NothingMoveSelector", doNothing, seqCheckDistanceHold, move);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
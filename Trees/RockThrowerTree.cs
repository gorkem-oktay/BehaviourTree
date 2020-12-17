using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using BehaviourTree.Leaf;


namespace BehaviourTree
{
    public class RockThrowerTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();
            var isCasting = new IsAbilityActiveNode(AbilityType.THROW);

            var changeDestination = new ChangeDestinationNode();
            
            var isPlayerClose = new IsPlayerCloseNode();
            var run = new FleeNode();
            var wait = new Wait(2.0f);
            var seqRun = new Sequence("RunSequence", isPlayerClose, run, changeDestination);

            var throwSomething = new ThrowNode();
            var seqThrow = new Sequence("ThrowSequence", wait, throwSomething);
            
            var checkArrived = new IsArrivedToDestinationNode();
            var seqChangeDestination = new Sequence("ChangeDestinationSequence", checkArrived, changeDestination);
            var move = new WalkNode();
            var seqMove = new Sequence("MoveSequence", new Succeeder(seqChangeDestination), move);

            var selector = new Selector("RunMoveSelector", doNothing, isCasting, seqRun, seqThrow, seqMove);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
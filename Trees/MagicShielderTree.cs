using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using BehaviourTree.Leaf;


namespace BehaviourTree
{
    public class MagicShielderTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();
            var isMagicShieldActive = new IsAbilityActiveNode(AbilityType.MAGIC_SHIELD);

            var changeDestination = new ChangeDestinationNode();
            
            var isPlayerClose = new IsPlayerCloseNode();
            var run = new FleeNode();
            var wait = new Wait(2.0f);
            var activateMagicShield = new ActivateAbilityNode(AbilityType.MAGIC_SHIELD);
            var seqMagicShield = new Sequence("MagicShieldSequence", wait, activateMagicShield);
            var seqRun = new Sequence("RunSequence", isPlayerClose, run, new Succeeder(seqMagicShield), changeDestination);

            var checkArrived = new IsArrivedToDestinationNode();
            var seqChangeDestination = new Sequence("ChangeDestinationSequence", checkArrived, changeDestination);
            var move = new WalkNode();
            var seqMove = new Sequence("MoveSequence", new Succeeder(seqChangeDestination), move);

            var selector = new Selector("RunMoveSelector", doNothing, isMagicShieldActive, seqRun, seqMove);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
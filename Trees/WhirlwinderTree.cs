using BehaviourTree.Composite;
using BehaviourTree.Decorator;

namespace BehaviourTree
{
    public class WhirlwinderTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var doNothing = new DoNothingNode();
            var isWhirlwindActive = new IsAbilityActiveNode(AbilityType.WHIRLWIND);
            var activateWhirlwind = new ActivateAbilityNode(AbilityType.WHIRLWIND);
            
            var selector = new Selector("WhirlwindSelector", doNothing, isWhirlwindActive, activateWhirlwind);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
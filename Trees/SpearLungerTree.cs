using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using EntityAttributes;

namespace BehaviourTree
{
    public class SpearLungerTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var context = (EnemyBehaviourTreeContext) _context;
            var ability = context.Self.GetAbilityManager().Get(AbilityType.SPEAR_LUNGE);
            
            var hold = new HoldNode();
            var isTargetInRangeForChase = new IsTargetInRangeNode(context.Self.GetAttributeManager().ValueOf(AttributeType.Vision));
            var isTargetInRangeForLunge = new IsTargetInRangeNode(ability.Range); 
            
            var seqCooldownHold = new Sequence("CooldownHoldSequence", 
                new IsAbilityOnCooldownNode(AbilityType.SPEAR_LUNGE),
                hold);
            
            var seqLunge = new Sequence("LungeSequence", 
                isTargetInRangeForLunge,
                new Selector("LockSequence", 
                    new IsAbilityActiveNode(AbilityType.SPEAR_LUNGE),
                    new LockOnTargetNode()),
                new ActivateAbilityNode(AbilityType.SPEAR_LUNGE));
            
            var seqChase = new Sequence("ChaseSequence", 
                isTargetInRangeForChase,
                new Inverter(new IsAbilityActiveNode(AbilityType.SPEAR_LUNGE)),
                new LockOnTargetNode(),
                new RunNode());

            var selector = new Selector("LungeSelector",
                new Inverter(new HasTarget()),
                seqCooldownHold,
                seqLunge,
                seqChase,
                hold);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
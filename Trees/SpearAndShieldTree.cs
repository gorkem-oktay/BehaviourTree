using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using EntityAttributes;

namespace BehaviourTree
{
    public class SpearAndShieldTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var context = (EnemyBehaviourTreeContext) _context;
            
            var abilityBlock = context.Self.GetAbilityManager().Get(AbilityType.BLOCK);
            var turn = new TurnNode(1f);
            
            var isTargetInVision = new IsTargetInRangeNode(context.Self.GetAttributeManager().ValueOf(AttributeType.Vision));
            var isTargetInBlockRange = new IsTargetInRangeNode(abilityBlock.Range);
            
            var seqBlock = new Sequence("BlockSequence", 
                isTargetInBlockRange,
                new ActivateAbilityNode(abilityBlock.Type),
                turn);

            var seqChase = new Sequence("ChaseSequence",
                isTargetInVision,
                new DeactivateAbilityNode(abilityBlock.Type),
                new LockOnTargetNode(),
                new WalkNode());

            var selector = new Selector("BlockChaseSelector",
                new Inverter(new HasTarget()),
                seqBlock,
                seqChase);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
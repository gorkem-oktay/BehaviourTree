using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using EntityAttributes;

namespace BehaviourTree
{
    public class JumpAttackerTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var context = (EnemyBehaviourTreeContext) _context;
            var ability = context.Self.GetAbilityManager().Get(AbilityType.JUMP_ATTACK);
            
            var hold = new HoldNode();
            
            var isJumpAttackOnCooldown = new IsAbilityOnCooldownNode(AbilityType.JUMP_ATTACK);
            var seqCooldownHold = new Sequence("CooldownHoldSequence", isJumpAttackOnCooldown, hold);
            
            var isTargetInRangeForAttack = new IsTargetInRangeNode(ability.Range);
            var activateJumpAttack = new ActivateAbilityNode(AbilityType.JUMP_ATTACK);
            var seqJumpAttack = new Sequence("JumpAttackSequence", isTargetInRangeForAttack, activateJumpAttack);

            var isTargetInRangeForChase = new IsTargetInRangeNode(context.Self.GetAttributeManager().ValueOf(AttributeType.Vision));
            var lockOnTarget = new LockOnTargetNode();
            var run = new RunNode();
            var seqChase = new Sequence("ChaseSequence", isTargetInRangeForChase, lockOnTarget, run);

            var selector = new Selector("JumpAttackSelector",
                new Inverter(new HasTarget()),
                seqCooldownHold,
                seqJumpAttack,
                seqChase,
                hold);

            var repeater = new Repeater(selector);

            return repeater;
        }
    }
}
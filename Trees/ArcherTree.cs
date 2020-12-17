using BehaviourTree.Composite;
using BehaviourTree.Decorator;
using EntityAttributes;

namespace BehaviourTree
{
    public class ArcherTree : IEnemyBehaviourTree
    {
        protected override INode CreateTree()
        {
            var context = (EnemyBehaviourTreeContext) _context;
            var abilityShoot = context.Self.GetAbilityManager().Get(AbilityType.SHOOT);
            var abilityDodge = context.Self.GetAbilityManager().Get(AbilityType.DODGE_LEFT);
            
            var hold = new HoldNode();
            var isTargetInVision = new IsTargetInRangeNode(context.Self.GetAttributeManager().ValueOf(AttributeType.Vision));
            
            // Lock Target
            
            var lockSequence = new Sequence("LockSequence",
                isTargetInVision,
                new LockOnTargetNode());
            
            //
            
            // Actions

            var seqDodge = new Sequence("DodgeSequence",
                new IsTargetInRangeNode(abilityDodge.Range),
                new Inverter(new IsAbilityOnCooldownNode(AbilityType.DODGE_LEFT)), 
                new Inverter(new IsAbilityOnCooldownNode(AbilityType.DODGE_RIGHT)),
                new Selector("DodgeSideSelector", 
                    new RandomBinary(new ActivateAbilityNode(AbilityType.DODGE_LEFT)),
                    new RandomBinary(new ActivateAbilityNode(AbilityType.DODGE_RIGHT))),
                new DeactivateAbilityNode(AbilityType.SHOOT));
            
            var selectorDodge = new Selector("DodgeSelector", 
                new IsAbilityActiveNode(AbilityType.DODGE_LEFT),
                new IsAbilityActiveNode(AbilityType.DODGE_RIGHT),
                seqDodge);
            
            var seqCooldownHold = new Sequence("CooldownHoldSequence", 
                new IsAbilityOnCooldownNode(AbilityType.SHOOT),
                hold);
            
            var seqShoot = new Sequence("ShootSequence", 
                new IsTargetInRangeNode(abilityShoot.Range), 
                new ActivateAbilityNode(AbilityType.SHOOT));
            
            var seqChase = new Sequence("ChaseSequence", 
                isTargetInVision,
                new RunNode());
            //

            var selectorAction = new Selector("ActionSelector",
                seqCooldownHold,
                seqShoot,
                seqChase,
                hold);

            var sequenceMain = new Sequence("MainSequence",
                new HasTarget(),
                new Inverter(selectorDodge),
                new Succeeder(lockSequence),
                selectorAction);
            
            var repeater = new Repeater(sequenceMain);

            return repeater;
        }
    }
}
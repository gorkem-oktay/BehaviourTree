using UnityEngine;

namespace BehaviourTree.Decorator
{
    public class RandomBinary : IDecorator {
        
        public RandomBinary(INode node) : base(node)
        {
        }
        
        public override Status OnBehave(IContext context)
        {
            var roll = Random.Range(0, 2);

            return roll == 0 ? child.OnBehave(context) : Status.FAILURE;
        }
    }
}
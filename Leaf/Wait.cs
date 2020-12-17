using UnityEngine;

namespace BehaviourTree.Leaf
{
    public class Wait : INode
    {
        public float Duration { get; set; }
        public float MinimumDuration { get; set; }
        public float MaximumDuration { get; set; }
        
        private bool shouldRandomize;
        private float currentTime;
        
        public Wait(float duration)
        {
            Duration = duration;
            shouldRandomize = false;
        }

        public Wait(float min, float max)
        {
            MinimumDuration = min;
            MaximumDuration = max;
            shouldRandomize = true;
            GenerateDuration();
        }

        private void GenerateDuration()
        {
            Duration = Random.Range(MinimumDuration, MaximumDuration);
        }
        
        public override Status OnBehave(IContext context)
        {
            currentTime += Time.fixedDeltaTime;

            if (currentTime < Duration)
            {
                return Status.FAILURE;
            }

            if (shouldRandomize)
            {
                GenerateDuration();
            }
            
            currentTime = 0;
            return Status.SUCCESS;
        }
    }
}

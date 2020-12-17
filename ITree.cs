using UnityEngine;

namespace BehaviourTree
{
    public abstract class ITree : MonoBehaviour
    {
        public bool IsPaused = true;
        
        protected INode _root;
        protected IContext _context;
        
        private void Awake()
        {
            OnAwake();
            
            _context = CreateContext();
            _root = CreateTree();
        }

        protected virtual void OnAwake()
        {
            
        }

        protected abstract INode CreateTree();

        protected virtual IContext CreateContext()
        {
            return null;
        }

        //protected abstract void UpdateState(State state);

        protected virtual void OnBeforeBehave()
        {
            
        }

        protected virtual void OnAfterBehave()
        {
            
        }

        private void FixedUpdate()
        {
            if (IsPaused)
            {
                return;
            }
            
            //UpdateState(state);
            
            OnBeforeBehave();
            _root?.Behave(_context);
            OnAfterBehave();
        }
    }
}

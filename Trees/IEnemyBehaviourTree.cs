using Map;
using StatusSystem;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class IEnemyBehaviourTree : ITree
    {
        protected Enemy _self;
        protected Player _player;
        protected GameObject _target;
        protected Boundary _boundary;
        
        protected override void OnAwake()
        {
            if (TryGetComponent(out Enemy enemy))
            {
                _self = enemy;    
            }
        }
        
        public void SetBoundary(Boundary boundary)
        {
            _boundary = boundary;
            ((EnemyBehaviourTreeContext) _context).Boundary = _boundary;
        }

        public void SetPlayer(Player player)
        {
            _player = player;
            ((EnemyBehaviourTreeContext) _context).Player = _player;
            ((EnemyBehaviourTreeContext) _context).PlayerStatusManager = _player.GetStatusManager();
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
            ((EnemyBehaviourTreeContext) _context).Target = _target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public GameObject GetContextTarget()
        {
            return ((EnemyBehaviourTreeContext) _context).Target;
        }

        protected override IContext CreateContext()
        {
            return new EnemyBehaviourTreeContext
            {
                Self = _self,
                Boundary = _boundary
            };
        }
    }
}
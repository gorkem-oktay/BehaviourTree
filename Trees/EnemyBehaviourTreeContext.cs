using Herbulles.BehaviourTree;
using Herbulles.Map;
using Herbulles.StatusSystem;
using UnityEngine;

namespace Herbulles
{
    public class EnemyBehaviourTreeContext : IContext
    {
        private Player _player;
        public Player Player
        {
            get => _player;
            set
            {
                _player = value;
                hasPlayer = value != null;
            }
        }

        private GameObject _target;

        public GameObject Target
        {
            get => _target;
            set
            {
                _target = value;
                hasTarget = value != null;
            }
        }
        
        public StatusManager PlayerStatusManager { get; set; }
        public bool hasPlayer = false;
        public bool hasTarget = false;

        public Enemy Self { get; set; }
        public Vector3 FleeDirection { get; set; }
        
        public Boundary Boundary { get; set; }
    }
}
using UnityEngine;

namespace BehaviourTree
{
    public class BehaviourTreeFactory
    {
        public enum Type
        {
            UNDEFINED = 0,
            COWARD = 1,
            FLEER = 2,
            MAGIC_SHIELDER = 3,
            ROCK_THROWER = 4,
            WHIRLWINDER = 5,
            CHASER = 6,
            JUMP_ATTACKER = 7,
            ARCHER = 8,
            SPEAR_AND_SHIELD = 9,
            SPEAR_LUNGER = 10,
            TODD = 100,
            SCARECROW = 101,
            ZEUS_PROLOGUE = 102
        }
        
        public static IEnemyBehaviourTree Add(GameObject enemy, Type type)
        {
            switch (type)
            {
                case Type.COWARD:
                    return enemy.AddComponent<CowardTree>();
                case Type.FLEER:
                    return enemy.AddComponent<FleerTree>();
                case Type.MAGIC_SHIELDER:
                    return enemy.AddComponent<MagicShielderTree>();
                case Type.ROCK_THROWER:
                    return enemy.AddComponent<RockThrowerTree>();
                case Type.WHIRLWINDER:
                    return enemy.AddComponent<WhirlwinderTree>();
                case Type.CHASER:
                    return enemy.AddComponent<ChaserTree>();
                case Type.JUMP_ATTACKER:
                    return enemy.AddComponent<JumpAttackerTree>();
                case Type.ARCHER:
                    return enemy.AddComponent<ArcherTree>();
                case Type.SPEAR_AND_SHIELD:
                    return enemy.AddComponent<SpearAndShieldTree>();
                case Type.SPEAR_LUNGER:
                    return enemy.AddComponent<SpearLungerTree>();
                case Type.TODD:
                    return enemy.AddComponent<ToddTree>();
                case Type.SCARECROW:
                    return enemy.AddComponent<ScarecrowTree>();
                case Type.ZEUS_PROLOGUE:
                    return enemy.AddComponent<ZeusPrologueTree>();
                case Type.UNDEFINED:
                default:
                    return null;
            }
        }
    }
}
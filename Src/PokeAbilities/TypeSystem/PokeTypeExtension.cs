using System;
using PokeAbilities.TypeSystem.TypeCardBufs;
using PokeAbilities.TypeSystem.TypeUnitBufs;

namespace PokeAbilities.TypeSystem
{
    /// <summary>
    /// <see cref="PokeType"/> の拡張メソッドを提供します。
    /// </summary>
    public static class PokeTypeExtension
    {
        /// <summary>
        /// この値のタイプを、それと等価なキャラクターに付与する状態に変換して返します。
        /// </summary>
        /// <param name="type">変換するタイプ。</param>
        /// <returns><paramref name="type"/> と同じタイプの状態。</returns>
        public static BattleUnitBuf ToUnitBuf(this PokeType type)
        {
            switch (type)
            {
                case PokeType.Normal:
                    break;
                case PokeType.Fire:
                    return new BattleUnitBuf_FireType();
                case PokeType.Water:
                    return new BattleUnitBuf_WaterType();
                case PokeType.Electric:
                    return new BattleUnitBuf_ElectricType();
                case PokeType.Grass:
                    break;
                case PokeType.Ice:
                    break;
                case PokeType.Fighting:
                    break;
                case PokeType.Poison:
                    break;
                case PokeType.Ground:
                    break;
                case PokeType.Flying:
                    break;
                case PokeType.Psychic:
                    break;
                case PokeType.Bug:
                    break;
                case PokeType.Rock:
                    break;
                case PokeType.Ghost:
                    break;
                case PokeType.Dragon:
                    break;
                case PokeType.Dark:
                    break;
                case PokeType.Steel:
                    break;
                case PokeType.Fairy:
                    break;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// この値のタイプを、それと等価なバトル ページに付与する状態に変換して返します。
        /// </summary>
        /// <param name="type">変換するタイプ。</param>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        /// <returns><paramref name="type"/> と同じタイプの状態。</returns>
        public static BattleDiceCardBuf CreateCardBuf(this PokeType type, bool isPermanent = false)
        {
            switch (type)
            {
                case PokeType.Normal:
                    return new BattleDiceCardBuf_NormalType(isPermanent);
                case PokeType.Fire:
                    return new BattleDiceCardBuf_FireType(isPermanent);
                case PokeType.Water:
                    return new BattleDiceCardBuf_WaterType(isPermanent);
                case PokeType.Electric:
                    return new BattleDiceCardBuf_ElectricType(isPermanent);
                case PokeType.Grass:
                    return new BattleDiceCardBuf_GrassType(isPermanent);
                case PokeType.Ice:
                    return new BattleDiceCardBuf_IceType(isPermanent);
                case PokeType.Fighting:
                    return new BattleDiceCardBuf_FightingType(isPermanent);
                case PokeType.Poison:
                    return new BattleDiceCardBuf_PoisonType(isPermanent);
                case PokeType.Ground:
                    return new BattleDiceCardBuf_GroundType(isPermanent);
                case PokeType.Flying:
                    return new BattleDiceCardBuf_FlyingType(isPermanent);
                case PokeType.Psychic:
                    return new BattleDiceCardBuf_PsychicType(isPermanent);
                case PokeType.Bug:
                    return new BattleDiceCardBuf_BugType(isPermanent);
                case PokeType.Rock:
                    return new BattleDiceCardBuf_RockType(isPermanent);
                case PokeType.Ghost:
                    return new BattleDiceCardBuf_GhostType(isPermanent);
                case PokeType.Dragon:
                    return new BattleDiceCardBuf_DragonType(isPermanent);
                case PokeType.Dark:
                    return new BattleDiceCardBuf_DarkType(isPermanent);
                case PokeType.Steel:
                    return new BattleDiceCardBuf_SteelType(isPermanent);
                case PokeType.Fairy:
                    return new BattleDiceCardBuf_FairyType(isPermanent);
            }

            throw new NotImplementedException();
        }
    }
}

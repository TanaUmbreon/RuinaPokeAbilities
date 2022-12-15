using System;
using System.Linq;

namespace PokeAbilities.Core
{
    /// <summary>
    /// タイプ相性を扱うユーティリティ クラスです。
    /// </summary>
    public static class TypeChart
    {
        /// <summary>タイプ相性表 ([攻撃側のタイプ, 防御側のタイプ] で指定する)</summary>
        private static readonly TypeEffectiveness[,] _chartTable;

        /// <summary>
        /// <see cref="TypeChart"/> の静的コンストラクタ。
        /// </summary>
        static TypeChart()
        {
            _chartTable = CreateNormalValueChartTable();

            // 第八世代時点での相性を設定する
            SetEffectiveness(attacker: PokeType.Normal, defender: PokeType.Rock, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Normal, defender: PokeType.Ghost, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Normal, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Water, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Grass, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Ice, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Bug, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Rock, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Dragon, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fire, defender: PokeType.Steel, TypeEffectiveness.SuperEffective);
            
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Fire, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Water, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Grass, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Ground, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Rock, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Water, defender: PokeType.Dragon, TypeEffectiveness.NotVeryEffective);
            
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Water, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Electric, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Grass, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Ground, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Flying, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Electric, defender: PokeType.Dragon, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Water, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Grass, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Ground, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Flying, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Bug, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Rock, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Dragon, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Grass, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Water, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Grass, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Ice, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Ground, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Flying, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Dragon, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ice, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Normal, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Ice, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Flying, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Psychic, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Bug, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Rock, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Ghost, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Dark, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Steel, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fighting, defender: PokeType.Fairy, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Grass, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Ground, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Rock, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Ghost, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Steel, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Poison, defender: PokeType.Fairy, TypeEffectiveness.SuperEffective);

            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Fire, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Electric, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Grass, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Poison, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Flying, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Bug, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Rock, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ground, defender: PokeType.Steel, TypeEffectiveness.SuperEffective);

            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Electric, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Grass, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Fighting, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Bug, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Rock, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Flying, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Psychic, defender: PokeType.Fighting, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Psychic, defender: PokeType.Poison, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Psychic, defender: PokeType.Psychic, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Psychic, defender: PokeType.Dark, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Psychic, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Grass, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Fighting, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Flying, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Psychic, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Ghost, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Dark, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Bug, defender: PokeType.Fairy, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Fire, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Ice, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Fighting, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Ground, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Flying, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Bug, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Rock, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Ghost, defender: PokeType.Normal, TypeEffectiveness.NoEffect);
            SetEffectiveness(attacker: PokeType.Ghost, defender: PokeType.Psychic, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ghost, defender: PokeType.Ghost, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Ghost, defender: PokeType.Dark, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Dragon, defender: PokeType.Dragon, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Dragon, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Dragon, defender: PokeType.Fairy, TypeEffectiveness.NoEffect);

            SetEffectiveness(attacker: PokeType.Dark, defender: PokeType.Fighting, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Dark, defender: PokeType.Psychic, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Dark, defender: PokeType.Ghost, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Dark, defender: PokeType.Dark, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Dark, defender: PokeType.Fairy, TypeEffectiveness.NotVeryEffective);

            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Water, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Electric, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Ice, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Rock, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Steel, defender: PokeType.Fairy, TypeEffectiveness.SuperEffective);

            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Fighting, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Dragon, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Dark, TypeEffectiveness.SuperEffective);
            SetEffectiveness(attacker: PokeType.Fairy, defender: PokeType.Steel, TypeEffectiveness.NotVeryEffective);
        }

        /// <summary>
        /// 全てのタイプ相性が効果普通で初期化されたタイプ相性表を生成します。
        /// </summary>
        /// <returns></returns>
        private static TypeEffectiveness[,] CreateNormalValueChartTable()
        {
            var typeValues = Enum.GetValues(typeof(PokeType)).Cast<int>();
            int typeCount = typeValues.Count();

            // PokeType型に一つもタイプが定義されていません。
            if (typeCount == 0) { throw new InvalidOperationException("No type is defined for the 'PokeType' type."); }

            int expectedValue = 0;
            foreach (int actualValue in typeValues.OrderBy(v => v))
            {
                // PokeType型のタイプの値がゼロから始まる連番になっていません。
                if (actualValue != expectedValue) { throw new InvalidOperationException("Type values of 'PokeType' type is not sequentially numbered starting from zero."); }
                expectedValue++;
            }

            var table = new TypeEffectiveness[typeCount, typeCount];
            foreach (int attackType in typeValues)
            {
                foreach (int defenseType in typeValues)
                {
                    table[attackType, defenseType] = TypeEffectiveness.Normal;
                }
            }
            return table;
        }

        /// <summary>
        /// タイプ相性表の値を設定します。
        /// </summary>
        /// <param name="attacker">攻撃側のタイプ。</param>
        /// <param name="defender">防御側のタイプ。</param>
        /// <param name="effectiveness"><paramref name="attacker"/> と <paramref name="defender"/> の相性に対応する効果。</param>
        private static void SetEffectiveness(PokeType attacker, PokeType defender, TypeEffectiveness effectiveness)
            => _chartTable[(int)attacker, (int)defender] = effectiveness;

        /// <summary>
        /// 指定したタイプ同士の相性による効果を取得します。
        /// </summary>
        /// <param name="attacker">攻撃側のタイプ。</param>
        /// <param name="defender">防御側のタイプ。</param>
        /// <returns></returns>
        public static TypeEffectiveness GetEffectiveness(PokeType attacker, PokeType defender) 
            => _chartTable[(int)attacker, (int)defender];
    }
}

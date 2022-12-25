using System;
using System.Linq;

namespace PokeAbilities.TypeSystem
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
            try
            {
                _chartTable = CreateChartTable();
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorOnExceptionThrown(ex);
                throw;
            }
        }

        /// <summary>
        /// 指定したタイプ同士の相性による効果を取得します。
        /// </summary>
        /// <param name="attacker">攻撃側のタイプ。</param>
        /// <param name="defender">防御側のタイプ。</param>
        /// <returns></returns>
        public static TypeEffectiveness GetEffectiveness(PokeType attacker, PokeType defender)
            => _chartTable[(int)attacker, (int)defender];

        /// <summary>
        /// タイプ相性表を生成します。
        /// </summary>
        /// <returns></returns>
        private static TypeEffectiveness[,] CreateChartTable()
        {
            int typeCount = GetTypeCount();
            var chartTable = new TypeEffectiveness[typeCount, typeCount];

            foreach (int attackType in Enumerable.Range(0, typeCount))
            {
                foreach (int defenseType in Enumerable.Range(0, typeCount))
                {
                    chartTable[attackType, defenseType] = TypeEffectiveness.Normal;
                }
            }

            // 第八世代時点での相性を設定する
            chartTable.Define(attacksFrom: PokeType.Normal, to: PokeType.Rock, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Normal, to: PokeType.Ghost, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Normal, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Fire, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Water, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Grass, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Ice, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Bug, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Rock, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Dragon, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fire, to: PokeType.Steel, asHaving: TypeEffectiveness.SuperEffective);

            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Fire, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Water, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Grass, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Ground, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Rock, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Water, to: PokeType.Dragon, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Water, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Electric, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Grass, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Ground, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Flying, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Electric, to: PokeType.Dragon, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Fire, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Water, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Grass, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Poison, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Ground, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Flying, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Bug, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Rock, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Dragon, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Grass, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Fire, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Water, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Grass, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Ice, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Ground, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Flying, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Dragon, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ice, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Normal, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Ice, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Poison, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Flying, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Psychic, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Bug, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Rock, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Ghost, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Dark, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Steel, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fighting, to: PokeType.Fairy, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Grass, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Poison, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Ground, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Rock, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Ghost, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Steel, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Poison, to: PokeType.Fairy, asHaving: TypeEffectiveness.SuperEffective);

            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Fire, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Electric, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Grass, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Poison, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Flying, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Bug, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Rock, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ground, to: PokeType.Steel, asHaving: TypeEffectiveness.SuperEffective);

            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Electric, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Grass, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Fighting, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Bug, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Rock, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Flying, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Psychic, to: PokeType.Fighting, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Psychic, to: PokeType.Poison, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Psychic, to: PokeType.Psychic, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Psychic, to: PokeType.Dark, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Psychic, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Fire, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Grass, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Fighting, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Poison, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Flying, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Psychic, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Ghost, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Dark, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Bug, to: PokeType.Fairy, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Fire, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Ice, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Fighting, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Ground, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Flying, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Bug, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Rock, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Ghost, to: PokeType.Normal, asHaving: TypeEffectiveness.NoEffect);
            chartTable.Define(attacksFrom: PokeType.Ghost, to: PokeType.Psychic, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ghost, to: PokeType.Ghost, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Ghost, to: PokeType.Dark, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Dragon, to: PokeType.Dragon, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Dragon, to: PokeType.Steel, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Dragon, to: PokeType.Fairy, asHaving: TypeEffectiveness.NoEffect);

            chartTable.Define(attacksFrom: PokeType.Dark, to: PokeType.Fighting, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Dark, to: PokeType.Psychic, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Dark, to: PokeType.Ghost, asHaving: TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Dark, to: PokeType.Dark, asHaving: TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Dark, to: PokeType.Fairy, asHaving: TypeEffectiveness.NotVeryEffective);

            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Water, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Electric, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Ice, TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Rock, TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Steel, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Steel, to: PokeType.Fairy, TypeEffectiveness.SuperEffective);

            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Fire, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Fighting, TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Poison, TypeEffectiveness.NotVeryEffective);
            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Dragon, TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Dark, TypeEffectiveness.SuperEffective);
            chartTable.Define(attacksFrom: PokeType.Fairy, to: PokeType.Steel, TypeEffectiveness.NotVeryEffective);

            return chartTable;
        }

        /// <summary>
        /// タイプの種類の数を取得します。
        /// </summary>
        /// <returns>タイプの種類の数。</returns>
        private static int GetTypeCount()
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

            return typeCount;
        }

        /// <summary>
        /// 指定した組のタイプ相性を定義します。
        /// </summary>
        /// <param name="attacksFrom">攻撃側のタイプ。</param>
        /// <param name="to">防御側のタイプ。</param>
        /// <param name="asHaving"><paramref name="attacksFrom"/> から <paramref name="to"/> に対して攻撃する時の相性の効果。</param>
        private static void Define(this TypeEffectiveness[,] chartTable, PokeType attacksFrom, PokeType to, TypeEffectiveness asHaving)
            => chartTable[(int)attacksFrom, (int)to] = asHaving;
    }
}

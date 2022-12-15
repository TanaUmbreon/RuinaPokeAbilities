using System.Collections.Generic;
using System.Linq;
using PokeAbilities.Core;
using PokeAbilities.TypedUnitBufs;

namespace PokeAbilities.Extensions
{
    /// <summary>
    /// <see cref="BattleUnitBufListDetail"/> の拡張メソッドを提供します。
    /// </summary>
    public static class BattleUnitBufListDetailExtension
    {
        /// <summary>
        /// 指定したタイプが状態として付与されている事を判定します。
        /// </summary>
        /// <param name="bufListDetail">判定する対象の状態リスト。</param>
        /// <param name="type">判定するタイプ。</param>
        /// <returns>指定したタイプが状態として付与されている場合は true、そうでない場合は false を返します。</returns>
        public static bool HasType(this BattleUnitBufListDetail bufListDetail, PokeType type)
            => bufListDetail.GetActivatedBufList().OfType<BattleUnitBufTypeBase>().Any(b => b.Type == type);

        /// <summary>
        /// 付与されているタイプのコレクションを取得します。
        /// </summary>
        /// <param name="bufListDetail">取得する対象の状態リスト。</param>
        /// <returns>状態として付与されているタイプのコレクション。</returns>
        public static IEnumerable<PokeType> GetTypes(this BattleUnitBufListDetail bufListDetail)
            => bufListDetail.GetActivatedBufList().OfType<BattleUnitBufTypeBase>().Select(b => b.Type);
    }
}

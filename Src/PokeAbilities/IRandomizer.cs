using System.Collections.Generic;

namespace PokeAbilities
{
    /// <summary>
    /// 疑似乱数を生成する機能を提供します。
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// 0 以上 1 未満のランダムな実数 (単精度浮動小数点数) を取得します。
        /// </summary>
        float ValueForProb { get; }

        /// <summary>
        /// 指定したリストからランダムに要素を一つ選択して返します。
        /// </summary>
        /// <typeparam name="T">リストの要素の型。</typeparam>
        /// <param name="list">選択対象となるリスト。</param>
        /// <returns><paramref name="list"/> に含まれている要素。</returns>
        T SelectOne<T>(List<T> list);

        /// <summary>
        /// 指定したコレクションの要素をランダムに並び替えて新しいコレクションとして返します。
        /// </summary>
        /// <typeparam name="T">コレクションの要素の型。</typeparam>
        /// <param name="items">並び替え対象のコレクション。</param>
        /// <returns>ランダムに並び替えられた <paramref name="items"/> の新しいコレクション。</returns>
        IEnumerable<T> Sort<T>(IEnumerable<T> items);
    }
}

using System.Linq;
using PokeAbilities.Core;
using PokeAbilities.TypedCardBufs;

namespace PokeAbilities.Extensions
{
    /// <summary>
    /// <see cref="BattleDiceCardModel"/> の拡張メソッドを提供します。
    /// </summary>
    public static class BattleDiceCardModelExtension
    {
        /// <summary>
        /// このバトル ページがタイプ付与されている事を判定します。
        /// </summary>
        /// <param name="card">判定する対象のバトル ページ。</param>
        /// <returns>タイプ付与されている場合は true、そうでない場合は false を返します。</returns>
        public static bool IsTyped(this BattleDiceCardModel card)
            => card.GetBufList().Any(b => b is BattleDiceCardBufTypeBase);

        /// <summary>
        /// このバトル ページがタイプ付与されている場合、そのタイプを取得します。複数のタイプが付与されている場合、
        /// </summary>
        /// <param name="card">タイプを取得する対象のバトル ページ。</param>
        /// <param name="type">タイプ付与されている場合はそのタイプ、そうでない場合は <see cref="PokeType.Normal"/> を返します。</param>
        /// <returns>タイプ付与されている場合は true、そうでない場合は false を返します。</returns>
        public static bool TryGetType(this BattleDiceCardModel card, out PokeType type)
        {
            type = PokeType.Normal;
            if (!card.IsTyped()) { return false; }

            var buf = card.GetBufList().First(b => b is BattleDiceCardBufTypeBase) as BattleDiceCardBufTypeBase;
            type = buf.Type;
            return true;
        }

        /// <summary>
        /// このバトル ページがタイプ付与されていない場合、指定したタイプを付与します。
        /// </summary>
        /// <param name="card">付与する対象のバトル ページ。</param>
        /// <param name="type">付与するタイプ。</param>
        /// <param name="isPermanent">幕をまたいでも永続的に状態が付与される事を示す値。省略時はその幕限り。</param>
        /// <returns>タイプ付与できた場合は true、すでに何らかのタイプが付与されてタイプ付与できなかった場合は false。</returns>
        public static bool TryAddType(this BattleDiceCardModel card, PokeType type, bool isPermanent = false)
        {
            if (card.IsTyped()) { return false; }
            card.AddBuf(type.CreateCardBuf(isPermanent));
            return true;
        }

        ///// <summary>
        ///// 指定したタイプがバトル ページ状態として付与されている事を判定します。
        ///// </summary>
        ///// <param name="card">判定する対象のバトル ページ。</param>
        ///// <param name="type">判定するタイプ。</param>
        ///// <returns>指定したタイプがバトル ページ状態として付与されている場合は true、そうでない場合は false を返します。</returns>
        //public static bool HasType(this BattleDiceCardModel card, PokeType type)
        //    => card.GetBufList().OfType<BattleDiceCardBufTypeBase>().Any(b => b.Type == type);

        ///// <summary>
        ///// 指定したタイプのコレクションに含まれるいずれかのタイプがバトル ページ状態として付与されている事を判定します。
        ///// </summary>
        ///// <param name="card">判定する対象のバトル ページ。</param>
        ///// <param name="types">判定するタイプのコレクション。</param>
        ///// <returns>いずれかのタイプがバトル ページ状態として付与されている場合は true、そうでない場合は false を返します。</returns>
        //public static bool HasTypeAny(this BattleDiceCardModel card, IEnumerable<PokeType> types)
        //    => card.GetBufList().OfType<BattleDiceCardBufTypeBase>().Any(b => types.Contains(b.Type));
    }
}

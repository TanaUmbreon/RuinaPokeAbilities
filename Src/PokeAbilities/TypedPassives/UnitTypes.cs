using System.Collections;
using System.Collections.Generic;
using PokeAbilities.Core;

namespace PokeAbilities.TypedPassives
{
    /// <summary>
    /// キャラクターのタイプのコレクションを表します。
    /// </summary>
    public class UnitTypes : IEnumerable<PokeType>
    {
        private readonly IEnumerable<PokeType> _types;

        /// <summary>
        /// <see cref="UnitTypes"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="type1">キャラクターが持つ 1 番目のタイプ。</param>
        /// <param name="type2">キャラクターが持つ 2 番目のタイプ。省略または null または 1 番目と同じタイプを指定した時は 2 番目のタイプはなしとします。</param>
        public UnitTypes(PokeType type1, PokeType? type2 = null)
        {
            _types = (type2.HasValue && type1 != type2.Value)
                ? new[] { type1, type2.Value } 
                : new[] { type1 };
        }

        public IEnumerator<PokeType> GetEnumerator()
            => _types.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}

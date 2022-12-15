using PokeAbilities.Core;

namespace PokeAbilities.TypedCardBufs
{
    /// <summary>
    /// バトル ページ状態「くさタイプ」
    /// くさタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_GrassType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Grass;
        public override string keywordId => "GrassType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_GrassType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_GrassType(bool isPermanent = false) : base(isPermanent) { }
    }
}

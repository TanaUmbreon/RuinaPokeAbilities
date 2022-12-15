using PokeAbilities.Core;

namespace PokeAbilities.TypedCardBufs
{
    /// <summary>
    /// バトル ページ状態「あくタイプ」
    /// あくタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_DarkType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Dark;
        public override string keywordId => "DarkType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_DarkType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_DarkType(bool isPermanent = false) : base(isPermanent) { }
    }
}

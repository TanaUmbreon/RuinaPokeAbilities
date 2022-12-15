using PokeAbilities.Core;

namespace PokeAbilities.TypedCardBufs
{
    /// <summary>
    /// バトル ページ状態「かくとうタイプ」
    /// かくとうタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_FightingType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Fighting;
        public override string keywordId => "FightingType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_FightingType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_FightingType(bool isPermanent = false) : base(isPermanent) { }
    }
}

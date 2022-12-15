using PokeAbilities.Core;

namespace PokeAbilities.TypedCardBufs
{
    /// <summary>
    /// バトル ページ状態「ドラゴンタイプ」
    /// ドラゴンタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_DragonType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Dragon;
        public override string keywordId => "DragonType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_DragonType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_DragonType(bool isPermanent = false) : base(isPermanent) { }
    }
}

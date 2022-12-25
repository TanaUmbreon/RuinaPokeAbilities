namespace PokeAbilities.Types.TypeCardBufs
{
    /// <summary>
    /// バトル ページ状態「フェアリータイプ」
    /// フェアリータイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_FairyType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Fairy;
        public override string keywordId => "FairyType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_FairyType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_FairyType(bool isPermanent = false) : base(isPermanent) { }
    }
}

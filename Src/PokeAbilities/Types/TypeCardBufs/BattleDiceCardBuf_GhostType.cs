namespace PokeAbilities.Types.TypeCardBufs
{
    /// <summary>
    /// バトル ページ状態「ゴーストタイプ」
    /// ゴーストタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_GhostType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Ghost;
        public override string keywordId => "GhostType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_GhostType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_GhostType(bool isPermanent = false) : base(isPermanent) { }
    }
}

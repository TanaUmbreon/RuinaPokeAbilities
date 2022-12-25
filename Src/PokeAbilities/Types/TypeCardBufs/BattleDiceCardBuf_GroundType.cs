namespace PokeAbilities.Types.TypeCardBufs
{
    /// <summary>
    /// バトル ページ状態「じめんタイプ」
    /// じめんタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_GroundType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Ground;
        public override string keywordId => "GroundType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_GroundType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_GroundType(bool isPermanent = false) : base(isPermanent) { }
    }
}

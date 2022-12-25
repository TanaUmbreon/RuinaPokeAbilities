namespace PokeAbilities.Types.TypeCardBufs
{
    /// <summary>
    /// バトル ページ状態「はがねタイプ」
    /// はがねタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_SteelType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Steel;
        public override string keywordId => "SteelType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_SteelType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_SteelType(bool isPermanent = false) : base(isPermanent) { }
    }
}

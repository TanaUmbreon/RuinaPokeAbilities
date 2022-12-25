namespace PokeAbilities.TypeSystem.TypeCardBufs
{
    /// <summary>
    /// バトル ページ状態「こおりタイプ」
    /// こおりタイプを持つキャラクターが使用したとき、このページで与えるダメージ・混乱ダメージ量+20%
    /// </summary>
    public class BattleDiceCardBuf_IceType : BattleDiceCardBufTypeBase
    {
        public override PokeType Type => PokeType.Ice;
        public override string keywordId => "IceType";

        /// <summary>
        /// <see cref="BattleDiceCardBuf_IceType"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="isPermanent">幕をまたいでも永続的にタイプ付与する事を示す値。省略した場合はその幕でのみタイプ付与します。</param>
        public BattleDiceCardBuf_IceType(bool isPermanent = false) : base(isPermanent) { }
    }
}

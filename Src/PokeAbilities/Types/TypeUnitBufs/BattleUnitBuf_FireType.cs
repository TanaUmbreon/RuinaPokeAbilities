namespace PokeAbilities.Types.TypeUnitBufs
{
    /// <summary>
    /// 状態「ほのおタイプ」<br/>
    /// タイプ付与されたページに対して以下の相性を持つ<br/>
    /// [効果はバツグンだ！]<br/>
    /// みず、じめん、いわ<br/>
    /// [効果は今ひとつのようだ……]<br/>
    /// ほのお、くさ、こおり、むし、はがね、フェアリー
    /// </summary>
    public class BattleUnitBuf_FireType : BattleUnitBufTypeBase
    {
        public override PokeType Type => PokeType.Fire;

        public override string keywordId => "FireType";
    }
}
